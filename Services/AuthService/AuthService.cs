using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.AccountService;
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

        public AuthService(
            AppDBContext dbContext,
            IMapper mapper,
            IOptionsMonitor<Jwt> monitor,
            IHttpContextAccessor httpContextAccessor,
            IAccountService accountService, IUserService userService
            )
        {
            _dbContext = dbContext;
            _accountService = accountService;
            _userService = userService;
            _mapper = mapper;
            _jwt = monitor.CurrentValue;
            _httpContextAccessor = httpContextAccessor;

        }
        public async Task<AuthVM> Login(AccountVM loginVM)
        {
            try
            {
                var accountUser = await _dbContext.AccountUser
                    .Include(x => x.Account)
                    .FirstOrDefaultAsync(x => x.Account.Email == loginVM.Email);

                if (accountUser != null)
                {
                    if (!VerifyPasswordHash(loginVM.Password, accountUser.Account.Password))
                    {
                        throw new ExceptionReturn(400, "Sai mật khẩu vui lòng nhập lại.");
                    }
                    if (!accountUser.Account.Status)
                    {
                        throw new ExceptionReturn(400, "Tài khoản chưa được kích hoạt");
                    }
                    var role = await _dbContext.UserRole.FirstOrDefaultAsync(x => x.UserId == accountUser.UserId);
                    var authvm = new AuthVM
                    {
                        UserId = accountUser.UserId,
                        AccountId = accountUser.AccountID,
                        RoleId = role.RoleId,
                        AccessToken = GenerateAccessToken(accountUser),
                        RefreshToken = GenerateRefreshToken(accountUser)
                    };
                    if (authvm != null)
                    {
                        var refreshTokenCookieOptions = new CookieOptions
                        {
                            HttpOnly = true,
                            Secure = true,
                            SameSite = SameSiteMode.None,
                        };
                        _httpContextAccessor.HttpContext.Response.Cookies.Append("RefreshToken", authvm.RefreshToken, refreshTokenCookieOptions);
                    }
                    return authvm;
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
        #region AccessToken
        private string GenerateAccessToken(AccountUser account)
        {
            try
            {
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var secretKeyBytes = Encoding.UTF8.GetBytes(_jwt.SecretKey);
                var tokenDesc = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim("Status", account.Account.Status.ToString()),
                    new Claim("IssuedAt", account.Account.IssuedAt.ToString()),
                    new Claim("ActivedAt", account.Account.ActivedAt.ToString()),
                    new Claim("UpdatedAt", account.Account.UpdatedAt.ToString()),
                    new Claim("AccountId", account.AccountID.ToString()),
                    new Claim("UserId", account.UserId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, account.Account.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, account.Account.Email),
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
        #endregion
        #region RefreshToken
        private string GenerateRefreshToken(AccountUser account)
        {
            //Tạo ngẫu nhiên bộ refresh token
            var random = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);
                var refreshToken = Convert.ToBase64String(random);
                var refreshTokenData = new RefreshToken
                {
                    User = account.User,
                    Token = refreshToken,
                    CreateAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddDays(30)
                };

                _dbContext.RefreshToken.Add(refreshTokenData);
                _dbContext.SaveChanges();
                return refreshToken;
            }
        }
        #endregion

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

        public async Task<AccountUser> RegisterCandidate(CandidateVM candidateVM, AccountVM account)
        {
            var accountExist = await _dbContext.Account.Where(prop => account.Email == prop.Email).FirstOrDefaultAsync();
            var userExist = await _dbContext.User.Where(prop => candidateVM.Email == prop.Email).FirstOrDefaultAsync();

            try
            {
                if (candidateVM.Email != account.Email)
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
                    var newCandidate = await _userService.AddCandidate(candidateVM);
                    var newAccountUser = new AccountUser
                    {
                        Account = newAccount,
                        User = newCandidate,
                        AccountID = newAccount.Id,
                        UserId = newCandidate.Id,
                    };
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
                    var newCandidate = await _userService.AddEmployer(employerVM);
                    var newAccountUser = new AccountUser
                    {
                        Account = newAccount,
                        User = newCandidate,
                        AccountID = newAccount.Id,
                        UserId = newCandidate.Id,
                    };
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


    }
}
