using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
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
        private readonly IMapper _mapper;
        private readonly Jwt _jwt;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(AppDBContext dbContext, IMapper mapper, IOptionsMonitor<Jwt> monitor, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _jwt = monitor.CurrentValue;
            _httpContextAccessor = httpContextAccessor;

        }
        public async Task<AuthVM> Login(LoginVM loginVM)
        {
            try
            {
                var accountUser = await _dbContext.AccountUser
                    .Include(x => x.Account)
                    .FirstOrDefaultAsync(x => x.Account.Email == loginVM.Email && x.Account.Password == loginVM.Password);

                if (accountUser != null)
                {
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
/*                            Secure = true,
                            SameSite = SameSiteMode.None,*/
                        };
                        _httpContextAccessor.HttpContext.Response.Cookies.Append("RefreshToken", authvm.RefreshToken, refreshTokenCookieOptions);
                    }
                    return authvm;
                }
                else
                {
                    throw new ExceptionReturn(404, "Sai mật khẩu hoặc email");
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
                throw new ExceptionReturn(500,"Không Generate được token.");
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

        public async Task<AccountUserVM> Register(UserVM user, AccountVM account, string role /*nếu là NTD->employer gán cứng từ controller, nếu là UV -> candidate*/)
        {
            //check tồn tại
            //chưa tồn tại -> tạo user = new candidate hoặc new employer tuỳ vào role
            throw new NotImplementedException();
        }

    }
}
