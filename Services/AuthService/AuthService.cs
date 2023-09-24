using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.AccountService;
using CVLookup_WebAPI.Services.RefreshTokenService;
using CVLookup_WebAPI.Services.UserRoleService;
using CVLookup_WebAPI.Services.UserService;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;

namespace CVLookup_WebAPI.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly AppDBContext _dbContext;
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly Jwt _jwt;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRoleService _userRoleService;
        private readonly IRefreshTokenService _refreshTokenService;

        public AuthService(
            AppDBContext dbContext,
            IMapper mapper,
            IOptionsMonitor<Jwt> monitor,
            IHttpContextAccessor httpContextAccessor,
            IAccountService accountService, 
            IUserService userService,
            IUserRoleService userRoleService,
            IRefreshTokenService refreshTokenService
            )
        {
            _dbContext = dbContext;
            _accountService = accountService;
            _userService = userService;
            _mapper = mapper;
            _jwt = monitor.CurrentValue;
            _httpContextAccessor = httpContextAccessor;
            _userRoleService = userRoleService;
            _refreshTokenService = refreshTokenService;
        }

        #region Login
        public async Task<AuthVM> Login(AccountVM loginVM)
        {
            try
            {
                var account = await _dbContext.Account
                    .FirstOrDefaultAsync(x => x.Email == loginVM.Email);

                if (account != null)
                {
                    if (!VerifyPasswordHash(loginVM.Password, account.Password))
                    {
                        throw new ExceptionReturn(400, "Sai mật khẩu vui lòng nhập lại.");
                    }
                    //if (!accountUser.Status)
                    //{
                    //    throw new ExceptionReturn(400, "Tài khoản chưa được kích hoạt");
                    //}
                    var accUser = await _dbContext.AccountUser.FirstOrDefaultAsync(x => x.AccountID == account.Id);
                    var user = _dbContext.User.FirstOrDefault(x => x.Id == accUser.UserId);
                    var role = await _dbContext.UserRole.FirstOrDefaultAsync(x => x.UserId == accUser.UserId);
                    var refreshToken = GenerateRefreshToken(account);
                    var authvm = new AuthVM
                    {
                        UserId = accUser.UserId,
                        AccountId = account.Id,
                        RoleId = role.RoleId,
                        TokenVM = new TokenVM
                        {
                            AccessToken = GenerateAccessToken(account),
                            RefreshToken = refreshToken
                        }
                    };
                    if (authvm != null)
                    {
                        var refreshTokenData = new RefreshToken
                        {
                            User = user,
                            UserId = user.Id,
                            Account = account,
                            Token = refreshToken,
                            CreateAt = DateTime.UtcNow,
                            ExpiredAt = DateTime.UtcNow.AddDays(30)
                        };
                        var checkExistRToken = await _dbContext.RefreshToken.FirstOrDefaultAsync(x => x.UserId == refreshTokenData.UserId);
                        if (checkExistRToken == null)
                        {
                            _refreshTokenService.AddRToken(refreshTokenData);
                        }
                        else
                        {
                            _refreshTokenService.EditRToken(refreshTokenData.UserId, refreshTokenData);
                        }
                        var refreshTokenCookieOptions = new CookieOptions
                        {
                            HttpOnly = true,
                            Secure = true,
                            SameSite = SameSiteMode.None,
                        };
                        _httpContextAccessor.HttpContext.Response.Cookies.Append("RefreshToken", authvm.TokenVM.RefreshToken, refreshTokenCookieOptions);
                        return authvm;
                    }
                    else
                    {
                        throw new ExceptionReturn(400, "Đăng nhập thất bại.");
                    }

                }
                else
                {
                    throw new ExceptionReturn(404, "Sai email vui lòng nhập lại.");
                }
            }
            catch (Exception e)
            {
                throw new ExceptionReturn(500, e.Message);
            }
        }

        private bool VerifyPasswordHash(string password, string hashedPassword)
        {
            byte[] combinedBytes = Convert.FromBase64String(hashedPassword);

            byte[] saltBytes = new byte[128 / 8];
            byte[] saltedPassword = new byte[combinedBytes.Length - saltBytes.Length];
            Buffer.BlockCopy(combinedBytes, 0, saltBytes, 0, saltBytes.Length);
            Buffer.BlockCopy(combinedBytes, saltBytes.Length, saltedPassword, 0, saltedPassword.Length);

            using (var hmac = new HMACSHA512(saltBytes))
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] computedHash = hmac.ComputeHash(passwordBytes);

                return computedHash.SequenceEqual(saltedPassword);
            }
        }
        #endregion

        #region AToken-RToken
        private string GenerateAccessToken(Account account)
        {
            try
            {
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var secretKeyBytes = Encoding.UTF8.GetBytes(_jwt.SecretKey);
                var user =  _dbContext.AccountUser.SingleOrDefault(prop => prop.AccountID == account.Id);
                string userID = user.UserId.ToString();
                var tokenDesc = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim("Status", account.Status.ToString()),
                    new Claim("IssuedAt", account.IssuedAt.ToString()),
                    new Claim("ActivedAt", account.ActivedAt.ToString()),
                    new Claim("UpdatedAt", account.UpdatedAt.ToString()),
                    new Claim("AccountId", account.Id.ToString()),
                    new Claim("UserId", userID),
                    new Claim(JwtRegisteredClaimNames.Email, account.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, account.Email),
                }),
                    Expires = DateTime.UtcNow.AddSeconds(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
                };
                var token = jwtTokenHandler.CreateToken(tokenDesc);
                var accessToken = jwtTokenHandler.WriteToken(token);

                return accessToken;
            }
            catch (Exception e)
            {
                throw new ExceptionReturn(500, "Không Generate được token.");
            }

        }


        private string GenerateRefreshToken(Account account)
        {
            //Tạo ngẫu nhiên bộ refresh token
            var random = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);
                var refreshToken = Convert.ToBase64String(random);
               
                return refreshToken;
            }
        }
        #endregion


        #region RenewToken
        public async Task<object> RenewToken(TokenVM tokenVM)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_jwt.SecretKey);
            var tokenValidateParam = new TokenValidationParameters
            {
                //Tự ký token
                ValidateIssuer = false,
                ValidateAudience = false,

                //Ký vào token
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = false
            };
            try
            {
                //check 1 Check Accesstoken valid format
                var tokenInVerification = jwtTokenHandler.ValidateToken(tokenVM.AccessToken, tokenValidateParam, out var validatedToken);

                //check 2 check alg
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals
                        (SecurityAlgorithms.HmacSha512, StringComparison.InvariantCultureIgnoreCase);
                    if (!result)
                    {
                        throw new ExceptionReturn(400, "Sai Token.");
                    }
                }

                //check 3 check AccessToken expire???
                var utcExpireDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
                var expireDate = ConvertUnixTimeToDateTime(utcExpireDate);
                if (expireDate > DateTime.UtcNow)
                {
                    throw new ExceptionReturn(403, "Token hết   hiệu lực.");
                }

                //check 4 check RF exist in DB
                var getToken =  _refreshTokenService.GetToken();
                if (getToken.Token!=tokenVM.RefreshToken) 
                {
                    throw new ExceptionReturn(403, "RToken không đúng.");
                }
                //var storedToken = await _dbContext.RefreshToken.FirstOrDefaultAsync(x => x.Token == tokenVM.RefreshToken);
                //if (storedToken == null)
                //{
                //    throw new ExceptionReturn(403, "RToken không đúng.");
                //}

                //CREATE NEW TOKEN
                var acc = await _dbContext.
                    Account.SingleOrDefaultAsync(u => u.Id == getToken.AccountId);
                if (acc != null)
                {
                    var newToken = new
                    {
                        NewToken = GenerateAccessToken(acc)
                    };
                    return newToken;
                }
                else
                {
                    throw new ExceptionReturn(400, "Không renew được token.");
                }

            }
            catch (ExceptionReturn e)
            {
                throw new ExceptionReturn(e.Code, e.Message);
            }
        }

        private DateTime ConvertUnixTimeToDateTime(long utcExpireDate)
        {
            var dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval.AddSeconds(utcExpireDate).ToUniversalTime();
            return dateTimeInterval;
        }
        #endregion

        


        #region Register 
        public async Task<AccountUser> RegisterCandidate(CandidateVM candidateVM, AccountVM accountVM)
        {
            var accountExist = await _dbContext.Account.Where(prop => accountVM.Email == prop.Email).FirstOrDefaultAsync();
            var userExist = await _dbContext.User.Where(prop => candidateVM.Email == prop.Email).FirstOrDefaultAsync();

            try
            {
                if (candidateVM.Email != accountVM.Email)
                {
                    throw new ExceptionReturn(400, "Thất bại. Email không khớp với nhau.");
                }
                if (accountExist != null && userExist != null)
                {
                    throw new ExceptionReturn(400, "Thất bại. Email đã tồn tại!");
                }
                else
                {
                    var newAccount = await _accountService.Add(accountVM);
                    var newCandidate = await _userService.AddCandidate(candidateVM);
                    var newAccountUser = new AccountUser
                    {
                        Account = newAccount,
                        User = newCandidate,
                        AccountID = newAccount.Id,
                        UserId = newCandidate.Id,
                    };
                    var role = await _dbContext.Role.SingleOrDefaultAsync(prop=> prop.RoleName=="Candidate");
                    var userRoleVM = new UserRoleVM
                    {
                        RoleId = role.Id, 
                        UserId = newCandidate.Id,
                        Role =role,
                        User = newCandidate,
                    };
                    await _userRoleService.Add(userRoleVM);
                    var result = await _dbContext.AccountUser.AddAsync(newAccountUser);
                    if (result.State.ToString() == "Added")
                    {
                        int saveState = await _dbContext.SaveChangesAsync();
                        if (saveState <= 0)
                        {
                            throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                        }
                        return newAccountUser;
                    }
                    else
                    {
                        throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình thêm dữ liệu");
                    }
                }
            }
            catch (ExceptionReturn e)
            {
                throw new ExceptionReturn(e.Code, e.Message);
            }

        }
        public async Task<AccountUser> RegisterEmployer(EmployerVM employerVM, AccountVM account)
        {
            var accountExist = await _dbContext.Account.Where(prop => account.Email == prop.Email).FirstOrDefaultAsync();
            var userExist = await _dbContext.User.Where(prop => employerVM.Email == prop.Email).FirstOrDefaultAsync();

            try
            {
                if (employerVM.Email != account.Email)
                {
                    throw new ExceptionReturn(400, "Thất bại. Email không khớp với nhau.");
                }
                if (accountExist != null && userExist != null)
                {
                    throw new ExceptionReturn(400, "Thất bại. Email đã tồn tại!");
                }
                else
                {
                    var newAccount = await _accountService.Add(account);
                    var newEmployer = await _userService.AddEmployer(employerVM);
                    var newAccountUser = new AccountUser
                    {
                        Account = newAccount,
                        User = newEmployer,
                        AccountID = newAccount.Id,
                        UserId = newEmployer.Id,
                    };

                    var role = await _dbContext.Role.SingleOrDefaultAsync(prop => prop.RoleName == "Employer");
                    var userRoleVM = new UserRoleVM
                    {
                        RoleId = role.Id,
                        UserId = newEmployer.Id,
                        Role = role,
                        User = newEmployer,
                    };
                    await _userRoleService.Add(userRoleVM);
                    var result = await _dbContext.AccountUser.AddAsync(newAccountUser);
                    if (result.State.ToString() == "Added")
                    {
                        int saveState = await _dbContext.SaveChangesAsync();
                        if (saveState <= 0)
                        {
                            throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                        }
                        return newAccountUser;
                    }
                    else
                    {
                        throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình thêm dữ liệu");
                    }
                }
            }
            catch (ExceptionReturn e)
            {
                throw new ExceptionReturn(e.Code, e.Message);
            }

        }
        #endregion



    }
}
