using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.AccountService;
using CVLookup_WebAPI.Services.AccountUserService;
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
		private readonly IAccountUserService _accountUserService;

		public AuthService(
			AppDBContext dbContext,
			IMapper mapper,
			IOptionsMonitor<Jwt> monitor,
			IHttpContextAccessor httpContextAccessor,
			IAccountService accountService,
			IUserService userService,
			IUserRoleService userRoleService,
			IRefreshTokenService refreshTokenService,
			IAccountUserService accountUserService
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
			_accountUserService = accountUserService;
		}

		#region Login
		public async Task<AuthVM> Login(AccountVM loginVM)
		{
			try
			{
				var account = await _dbContext.Account.Where(prop => prop.Email == loginVM.Email).FirstOrDefaultAsync();
				if (account != null)
				{
					bool checkPassword = VerifyPasswordHash(loginVM.Password, account.Password);
					if (checkPassword)
					{
						var accessToken = GenerateAccessToken(account);
						var refreshToken = GenerateRefreshToken();

						var accountUser = await _accountUserService.GetByAccountId(account.Id);
						var userRole = await _userRoleService.GetByUserId(accountUser.UserId);

						var authReturn = new AuthVM
						{
							AccountId = account.Id,
							RoleId = userRole.RoleId,
							UserId = accountUser.UserId,
							TokenVM = new TokenVM
							{
								AccessToken = accessToken,
								RefreshToken = refreshToken
							}
						};

						var oldRefreshInDB = await _dbContext.RefreshToken
							.Where(prop => prop.AccountId == account.Id && accountUser.UserId == prop.UserId)
							.FirstOrDefaultAsync();
						if (oldRefreshInDB == null)
						{
							var refreshTokenVM = new RefreshTokenVM
							{
								UserId = accountUser.UserId,
								AccountId = account.Id,
								Token = refreshToken
							};

							await _refreshTokenService.AddRToken(_mapper.Map<RefreshToken>(refreshTokenVM));

						}
						else
						{
							oldRefreshInDB.Token = refreshToken;
							oldRefreshInDB.CreateAt = DateTime.Now;
							oldRefreshInDB.ExpiredAt = DateTime.Now.AddDays(7);
							await _refreshTokenService.EditRToken(oldRefreshInDB.UserId, oldRefreshInDB.AccountId, oldRefreshInDB);
						}
						var cookieOptions = new CookieOptions
						{
							HttpOnly = true,
							Secure = false,
							SameSite = SameSiteMode.None,
						};
						_httpContextAccessor.HttpContext.Response.Cookies.Append("RefreshToken", refreshToken, cookieOptions);
						return authReturn;
					}
					else
					{
						throw new ExceptionReturn(400, "Thất bại. Email hoặc mật khẩu không đúng");
					}
				}
				else
				{
					throw new ExceptionReturn(404, "Thất bại. Email hoặc mật khẩu không đúng");
				}
			}
			catch (ExceptionReturn e)
			{
				throw new ExceptionReturn(e.Code, e.Message);
			}
		}

		private bool VerifyPasswordHash(string password, string hashedPassword)
		{
			try
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
			catch (ExceptionReturn e)
			{
				throw new ExceptionReturn(e.Code, e.Message);
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
				var user = _dbContext.AccountUser.SingleOrDefault(prop => prop.AccountID == account.Id);
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
				if (token == null)
				{
					throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình tạo access token");
				}
				var accessToken = jwtTokenHandler.WriteToken(token);
				if (accessToken == null)
				{
					throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình ghi access token");
				}
				return accessToken;
			}
			catch (ExceptionReturn e)
			{
				throw new ExceptionReturn(e.Code, e.Message);
			}

		}


		private string GenerateRefreshToken()
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
		public async Task<object> RenewToken()
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
                string accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];

                if (!string.IsNullOrEmpty(accessToken) && accessToken.StartsWith("Bearer "))
                {
                    accessToken = accessToken.Substring("Bearer ".Length).Trim();
                }
                else
                {
                    throw new ExceptionReturn(400, "Token không hợp lệ hoặc không tồn tại.");
                }


                //check 1 Check Accesstoken valid format
                var tokenInVerification = jwtTokenHandler.ValidateToken(accessToken, tokenValidateParam, out var validatedToken);

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

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.ReadJwtToken(accessToken);
                var userIdClaim = token.Claims.FirstOrDefault(claim => claim.Type == "UserId").Value;
                var refreshTokenInDB = _dbContext.RefreshToken.FirstOrDefault(x => x.UserId == userIdClaim);
                string cookieValue = _httpContextAccessor.HttpContext.Request.Cookies["RefreshToken"];
				if (refreshTokenInDB.Token != cookieValue)
				{
					throw new ExceptionReturn(403, "RToken không đúng.");
				}

				//CREATE NEW TOKEN
				var accountIdClaim = token.Claims.FirstOrDefault(claim => claim.Type == "AccountId").Value;
                var account = await _dbContext.
					Account.SingleOrDefaultAsync(acc => acc.Id == accountIdClaim);
				if (account != null)
				{
					var newToken = new
					{
						NewToken = GenerateAccessToken(account)
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
					var role = await _dbContext.Role.SingleOrDefaultAsync(prop => prop.RoleName == "Candidate");
					var userRoleVM = new UserRoleVM
					{
						RoleId = role.Id,
						UserId = newCandidate.Id,
						Role = role,
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


        public async Task Logout()
        {
            try
            {
                string accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];

                if (!string.IsNullOrEmpty(accessToken) && accessToken.StartsWith("Bearer "))
                {
                    accessToken = accessToken.Substring("Bearer ".Length).Trim();
                }
                else
                {
                    throw new ExceptionReturn(400, "Token không hợp lệ hoặc không tồn tại.");
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.ReadJwtToken(accessToken);
                var userIdClaim = token.Claims.FirstOrDefault(claim => claim.Type == "UserId").Value;
                var accountIdClaim = token.Claims.FirstOrDefault(claim => claim.Type == "AccountId").Value;
                if (userIdClaim == null || accountIdClaim == null)
				{
					throw new ExceptionReturn(400, "Có lỗi xảy ra trong quá trình xử lýs");
				}
				await _refreshTokenService.DeleteRToken(userIdClaim, accountIdClaim);

                _httpContextAccessor.HttpContext.Response.Cookies.Delete("RefreshToken");

                return;
            }
            catch (ExceptionReturn e)
            {
                throw new ExceptionReturn(e.Code, e.Message);
            }
        }

    }
}
