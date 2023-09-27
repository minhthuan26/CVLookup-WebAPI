using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.AccountService;
using CVLookup_WebAPI.Services.AccountUserService;
using CVLookup_WebAPI.Services.MailService;
using CVLookup_WebAPI.Services.RefreshTokenService;
using CVLookup_WebAPI.Services.RoleService;
using CVLookup_WebAPI.Services.UserRoleService;
using CVLookup_WebAPI.Services.UserService;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using System.Collections;
using System.Collections.Specialized;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

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
		private readonly ITokenService _tokenService;
		private readonly IAccountUserService _accountUserService;
		private readonly IConfiguration _configuration;
		private readonly IRoleService _roleService;
		private readonly IMailService _mailService;
		private readonly IWebHostEnvironment _env;

		public AuthService(
			AppDBContext dbContext,
			IMapper mapper,
			IOptionsMonitor<Jwt> monitor,
			IHttpContextAccessor httpContextAccessor,
			IAccountService accountService,
			IUserService userService,
			IUserRoleService userRoleService,
			ITokenService tokenService,
			IAccountUserService accountUserService,
			IConfiguration configuration,
			IRoleService roleService,
			IMailService mailService,
			IWebHostEnvironment env
			)
		{
			_dbContext = dbContext;
			_accountService = accountService;
			_userService = userService;
			_mapper = mapper;
			_jwt = monitor.CurrentValue;
			_httpContextAccessor = httpContextAccessor;
			_userRoleService = userRoleService;
			_tokenService = tokenService;
			_accountUserService = accountUserService;
			_configuration = configuration;
			_roleService = roleService;
			_mailService = mailService;
			_env = env;
		}

		private string GetSecretKey()
		{
			return _configuration.GetValue<string>("JwtConfig:SECRET_KEY");
		}

		private string GetRefreshKey()
		{
			return _configuration.GetValue<string>("JwtConfig:REFRESH_KEY");
		}
		private string GetMailKey()
		{
			return _configuration.GetValue<string>("MailConfig:MAIL_KEY");
		}

		#region Login
		public async Task<object> Login(AccountVM accountVM)
		{
			try
			{
				var account = await _dbContext.Account.Where(prop => prop.Email == accountVM.Email).FirstOrDefaultAsync();
				if (account != null)
				{
					bool checkPassword = VerifyPasswordHash(accountVM.Password, account.Password);
					if (checkPassword)
					{
						var accountUser = await _accountUserService.GetByAccountId(account.Id);
						var userRole = await _userRoleService.GetByUserId(accountUser.UserId);

						var claims = new ListDictionary();
						claims.Add("accountId", account.Id);
						claims.Add("userId", userRole.UserId);
						claims.Add("roleId", userRole.RoleId);

						string accessToken = await GenerateToken(GetSecretKey(), claims, DateTime.Now.AddMinutes(10));
						string refreshToken = await GenerateToken(GetRefreshKey(), claims, DateTime.Now.AddMinutes(10));

						var authReturn = new
						{
							AccessToken = accessToken,
							RefreshToken = refreshToken
						};

						var oldRefreshInDB = await _dbContext.Token
							.Where(prop => prop.AccountId == account.Id && accountUser.UserId == prop.UserId)
							.FirstOrDefaultAsync();
						if (oldRefreshInDB == null)
						{
							var tokenVM = new TokenVM
							{
								UserId = accountUser.UserId,
								AccountId = account.Id,
								RoleId = userRole.RoleId,
								RefreshToken = refreshToken
							};

							await _tokenService.AddRefreshToken(tokenVM);

						}
						else
						{
							var tokenVM = new TokenVM
							{
								UserId = oldRefreshInDB.UserId,
								AccountId = oldRefreshInDB.AccountId,
								RoleId = oldRefreshInDB.Role.Id,
								RefreshToken = refreshToken
							};
							await _tokenService.EditRefreshToken(tokenVM);
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

		public async Task<string> GenerateToken(string key, ListDictionary data, DateTime expires)
		{
			try
			{
				var signingCredential = new SigningCredentials(
					new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
					SecurityAlgorithms.HmacSha512Signature
				);
				var claims = new List<Claim>();
				if (data.Count > 0)
				{
					foreach (DictionaryEntry entry in data)
					{
						claims.Add(new(entry.Key.ToString(), entry.Value.ToString()));
					}
				}

				var tokenDescript = new JwtSecurityToken(
					claims: claims,
					expires: expires,
					signingCredentials: signingCredential
				);

				var token = new JwtSecurityTokenHandler().WriteToken(tokenDescript);
				if (token == null)
				{
					throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình ghi token");
				}
				return token;
			}
			catch (ArgumentOutOfRangeException e)
			{
				throw new ExceptionReturn(500, "Thất bại. Độ dài khoá không hợp lệ. " + e.Message);
			}
			catch (Exception e)
			{
				throw new ExceptionReturn(500, e.Message);
			}

		}

		public async Task<JwtSecurityToken> ValidateToken(string token, string key)
		{
			try
			{
				var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

				var validationParameters = new TokenValidationParameters
				{
					ValidateIssuer = false,
					ValidateAudience = false,

					ValidateIssuerSigningKey = true,
					IssuerSigningKeys = new List<SecurityKey> { signingKey },
					ValidateLifetime = true
				};


				var tokenHandler = new JwtSecurityTokenHandler();
				tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
				var jwt = (JwtSecurityToken)validatedToken;

				return jwt;
			}
			catch (SecurityTokenValidationException e)
			{
				throw new ExceptionReturn(400, "Thất bại. Token không hợp lệ");
			}
		}

		private async Task<bool> CheckTokenExpired(string token, string key)
		{
			try
			{
				JwtSecurityToken result = await ValidateToken(token, key);
				if (!(result.ValidTo < DateTime.Now))
				{
					return true;
				}
			}
			catch (ExceptionReturn e)
			{
				throw new ExceptionReturn(e.Code, e.Message);
			}
			return false;
		}

		public async Task<object> RenewToken()
		{
			try
			{
				string accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
				string refreshToken = _httpContextAccessor.HttpContext.Request.Cookies["RefreshToken"];

				if (string.IsNullOrEmpty(accessToken) || string.IsNullOrEmpty(refreshToken))
				{
					throw new ExceptionReturn(400, "Thất bại. Không tìm thấy token");
				}

				accessToken = accessToken.Split(" ")[1];
				if (!await CheckTokenExpired(accessToken, GetSecretKey()))
				{
					throw new ExceptionReturn(400, "Thất bại. Không thể tạo mới access token vì token chưa hết hạn");
				}

				var tokenInDB = await _tokenService.GetTokenByValue(refreshToken);
				if (await CheckTokenExpired(tokenInDB.RefreshToken, GetRefreshKey()))
				{
					throw new ExceptionReturn(400, "Thất bại. Không thể tạo mới access token vì refresh token hết hạn");
				}

				var claims = new ListDictionary();
				claims.Add("accountId", tokenInDB.AccountId);
				claims.Add("userId", tokenInDB.UserId);
				claims.Add("roleId", tokenInDB.Role.Id);

				var newAccessToken = await GenerateToken(GetSecretKey(), claims, DateTime.Now.AddMinutes(10));
				var newRefreshToken = await GenerateToken(GetRefreshKey(), claims, DateTime.Now.AddDays(7));
				return new
				{
					AccessToken = newAccessToken,
					RefreshToken = newRefreshToken
				};
			}
			catch (ExceptionReturn e)
			{
				throw new ExceptionReturn(e.Code, e.Message);
			}
		}


		#region Register 
		public async Task<AccountUser> RegisterCandidate(CandidateVM candidateVM, AccountVM accountVM)
		{
			try
			{
				var newAccount = await _accountService.Add(accountVM);
				var newCandidate = await _userService.AddCandidate(candidateVM);

				var role = await _roleService.GetRoleByValue("Candidate");
				var userRoleVM = new UserRoleVM
				{
					RoleId = role.Id,
					UserId = newCandidate.Id
				};
				await _userRoleService.Add(userRoleVM);

				var newAccountUserVM = new AccountUserVM
				{
					AccountId = newAccount.Id,
					UserId = newCandidate.Id
				};
				var result = await _accountUserService.Add(newAccountUserVM);

				await SendMailToActiveAccount(newAccount);
				return result;
			}
			catch (ExceptionReturn e)
			{
				throw new ExceptionReturn(e.Code, e.Message);
			}

		}
		public async Task<AccountUser> RegisterEmployer(EmployerVM employerVM, AccountVM accountVM)
		{
			try
			{
				var newAccount = await _accountService.Add(accountVM);
				var newCandidate = await _userService.AddEmployer(employerVM);

				var role = await _roleService.GetRoleByValue("Employer");
				var userRoleVM = new UserRoleVM
				{
					RoleId = role.Id,
					UserId = newCandidate.Id
				};
				await _userRoleService.Add(userRoleVM);

				var newAccountUserVM = new AccountUserVM
				{
					AccountId = newAccount.Id,
					UserId = newCandidate.Id
				};
				var result = await _accountUserService.Add(newAccountUserVM);

				return result;
			}
			catch (ExceptionReturn e)
			{
				throw new ExceptionReturn(e.Code, e.Message);
			}

		}
		#endregion

		private async Task SendMailToActiveAccount(Account account)
		{
			try
			{
				var claims = new ListDictionary();
				claims.Add("Account", account);
				string activeToken = await GenerateToken(GetMailKey(), claims, DateTime.Now.AddDays(1));
				string activeLink = "http://localhost:4026/api/v1/active-account?token=" + activeToken;
				string subject = "Xác thực email cho tài khoản CVLookup của bạn";
				var webRoot = _env.WebRootPath;
				var filePath = webRoot + "\\mail_template.html";
				var builder = new BodyBuilder();
				using (StreamReader reader = System.IO.File.OpenText(filePath))
				{
					builder.HtmlBody = reader.ReadToEnd();
				}
				builder.HtmlBody = builder.HtmlBody.Replace("{{activeLink}}", activeLink);
				string message = builder.HtmlBody;
				await _mailService.sendMail(account.Email, subject, message);
			}
			catch (ExceptionReturn e)
			{
				throw new ExceptionReturn(e.Code, e.Message);
			}
			catch (Exception e)
			{
				throw new ExceptionReturn(500, e.Message);
			}
		}

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
					throw new ExceptionReturn(400, "RefreshToken không hợp lệ hoặc không tồn tại.");
				}

				var tokenHandler = new JwtSecurityTokenHandler();
				var token = tokenHandler.ReadJwtToken(accessToken);
				var userIdClaim = token.Claims.FirstOrDefault(claim => claim.Type == "UserId").Value;
				var accountIdClaim = token.Claims.FirstOrDefault(claim => claim.Type == "AccountId").Value;
				if (userIdClaim == null || accountIdClaim == null)
				{
					throw new ExceptionReturn(400, "Có lỗi xảy ra trong quá trình xử lýs");
				}
				await _tokenService.DeleteRefreshToken(userIdClaim, accountIdClaim);

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
