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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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
		private readonly IDbContextTransaction _transaction;

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
			IDbContextTransaction transaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				var account = await _dbContext.Account.Where(prop => prop.Email == accountVM.Email).FirstOrDefaultAsync();

				if (account != null)
				{
					if (!account.Actived)
					{
						throw new ExceptionReturn(400, "Thất bại. Tài khoản của bạn chưa được kích hoạt, vui lòng kiểm tra email để kích hoạt tài khoản");
					}
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
						string refreshToken = await GenerateToken(GetRefreshKey(), claims, DateTime.Now.AddDays(7));

						var authReturn = new
						{
							AccessToken = accessToken,
							RefreshToken = refreshToken
						};

						var oldRefreshInDB = await _tokenService.GetTokenById(userRole.UserId, accountUser.AccountId);

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
						await transaction.CommitAsync();
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
				await transaction.RollbackAsync();
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

		public async Task<VerifyTokenResult> VerifyToken(string token, string key)
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

				return new VerifyTokenResult
				{
					IsExpired = false,
					IsValid = true,
					Token = jwt
				};
			}
			catch (SecurityTokenExpiredException)
			{
				return new VerifyTokenResult
				{
					IsExpired = true,
					IsValid = true,
					Token = null
				};
			}
			catch (SecurityTokenValidationException)
			{
				return new VerifyTokenResult
				{
					IsExpired = false,
					IsValid = false,
					Token = null
				};
			}

			catch (ArgumentException)
			{
				return new VerifyTokenResult
				{
					IsExpired = false,
					IsValid = false,
					Token = null
				};
			}
		}

		public async Task<object> RenewToken()
		{
			IDbContextTransaction transaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				string accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
				string refreshToken = _httpContextAccessor.HttpContext.Request.Cookies["RefreshToken"];

				if (string.IsNullOrEmpty(accessToken) || string.IsNullOrEmpty(refreshToken))
				{
					throw new ExceptionReturn(400, "Thất bại. Không tìm thấy token");
				}

				accessToken = accessToken.Split(" ")[1];
				VerifyTokenResult accessTokenVerified = await VerifyToken(accessToken, GetSecretKey());
				if (!accessTokenVerified.IsValid)
				{
					throw new ExceptionReturn(400, "Thất bại. Token không hợp lệ");
				}
				if (!accessTokenVerified.IsExpired)
				{
					throw new ExceptionReturn(400, "Thất bại. Không thể tạo mới token vì token cũ vẫn chưa hết hạn");
				}

				var tokenInDB = await _tokenService.GetTokenByValue(refreshToken);
				VerifyTokenResult refreshTokenVerified = await VerifyToken(tokenInDB.RefreshToken, GetRefreshKey());
				if (!refreshTokenVerified.IsValid)
				{
					throw new ExceptionReturn(400, "Thất bại. Token không hợp lệ");
				}
				if (refreshTokenVerified.IsExpired)
				{
					throw new ExceptionReturn(400, "Thất bại. Không thể tạo mới token vì refresh token hết hạn, vui lòng đăng nhập lại");
				}

				var claims = new ListDictionary();
				claims.Add("accountId", tokenInDB.AccountId);
				claims.Add("userId", tokenInDB.UserId);
				claims.Add("roleId", tokenInDB.Role.Id);

				var newAccessToken = await GenerateToken(GetSecretKey(), claims, DateTime.Now.AddMinutes(10));
				var newRefreshToken = await GenerateToken(GetRefreshKey(), claims, DateTime.Now.AddDays(7));

				await _tokenService.EditRefreshToken(new TokenVM
				{
					AccountId = tokenInDB.AccountId,
					UserId = tokenInDB.UserId,
					RoleId = tokenInDB.RoleId,
					RefreshToken = newRefreshToken
				});

				await transaction.CommitAsync();
				var cookieOptions = new CookieOptions
				{
					HttpOnly = true,
					Secure = false,
					SameSite = SameSiteMode.None,
				};
				_httpContextAccessor.HttpContext.Response.Cookies.Append("RefreshToken", newRefreshToken, cookieOptions);
				return new
				{
					AccessToken = newAccessToken,
					RefreshToken = newRefreshToken
				};
			}
			catch (ExceptionReturn e)
			{
				await transaction.RollbackAsync();
				throw new ExceptionReturn(e.Code, e.Message);
			}
		}


		#region Register 
		public async Task<AccountUser> RegisterCandidate(CandidateVM candidateVM, AccountVM accountVM)
		{
			IDbContextTransaction transaction = await _dbContext.Database.BeginTransactionAsync();
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
				await transaction.CommitAsync();
				return result;
			}
			catch (ExceptionReturn e)
			{
				await transaction.RollbackAsync();
				throw new ExceptionReturn(e.Code, e.Message);
			}

		}
		public async Task<AccountUser> RegisterEmployer(EmployerVM employerVM, AccountVM accountVM)
		{
			IDbContextTransaction transaction = await _dbContext.Database.BeginTransactionAsync();
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
				await SendMailToActiveAccount(newAccount);
				await transaction.CommitAsync();
				return result;
			}
			catch (ExceptionReturn e)
			{
				await transaction.RollbackAsync();
				throw new ExceptionReturn(e.Code, e.Message);
			}

		}
		#endregion

		private async Task SendMailToActiveAccount(Account account)
		{
			try
			{
				string appHost = _configuration.GetValue<string>("AppConfig:HOST");
				string appPort = _configuration.GetValue<string>("AppConfig:PORT");
				var claims = new ListDictionary();
				claims.Add("AccountId", account.Id);
				string activeToken = await GenerateToken(GetMailKey(), claims, DateTime.Now.AddDays(7));
				string activeLink = appHost + ":" + appPort + "/api/v1/auth/active-account?token=" + activeToken;
				string subject = "Xác thực email cho tài khoản CVLookup của bạn";

				var webRoot = _env.WebRootPath;
				var filePath = webRoot + "\\mail_template.html.t";

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

		public async Task<object> Logout()
		{
			IDbContextTransaction transaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				string accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
				string refreshToken = _httpContextAccessor.HttpContext.Request.Cookies["RefreshToken"];

				if (string.IsNullOrEmpty(accessToken) || !accessToken.StartsWith("Bearer ") || string.IsNullOrEmpty(refreshToken))
				{
					throw new ExceptionReturn(400, "Thất bại. Yêu cầu không hợp lệ");
				}

				await _tokenService.DeleteRefreshToken(refreshToken);
				_httpContextAccessor.HttpContext.Response.Cookies.Delete("RefreshToken");
				await transaction.CommitAsync();
				return true;
			}
			catch (ExceptionReturn e)
			{
				await transaction.RollbackAsync();
				throw new ExceptionReturn(e.Code, e.Message);
			}
		}

		public async Task<object> ActiveAccount(string activeToken)
		{
			IDbContextTransaction transaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				if (string.IsNullOrEmpty(activeToken))
				{
					throw new ExceptionReturn(400, "Thất bại. Token không hợp lệ");
				}

				VerifyToken(activeToken, GetMailKey());

				VerifyTokenResult tokenVerified = await VerifyToken(activeToken, GetMailKey());
				if (tokenVerified.IsExpired)
				{
					throw new ExceptionReturn(400, "Thất bại. Token đã hết hạn, bạn đã không kích hoạt tài khoản trong vòng 7 ngày. Để sử dụng dịch vụ của CVLookup vui lòng đăng kí lại và nhận email kích hoạt tài khoản");
				}
				if (!tokenVerified.IsValid)
				{
					throw new ExceptionReturn(400, "Thất bại. Token không hợp lệ");
				}
				string accountId = tokenVerified.Token.Claims.FirstOrDefault(prop => prop.Type == "AccountId").Value;
				var account = await _accountService.GetAccountById(accountId);
				if (account.Actived)
				{
					throw new ExceptionReturn(400, "Thất bại. Tài khoản này đã được kích hoạt trước đó");
				}

				var accountVM = new AccountVM
				{
					ActivedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					Actived = true,
					Email = account.Email,
					Password = account.Password
				};
				var result = await _accountService.Update(accountId, accountVM);

				await transaction.CommitAsync();
				return new
				{
					AccountId = result.Id,
					Email = result.Email,
					Actived = result.Actived,
					IssuedAt = result.IssuedAt,
					UpdatedAt = result.UpdatedAt,
					ActivedAt = result.ActivedAt
				};
			}
			catch (ExceptionReturn e)
			{
				await transaction.RollbackAsync();
				throw new ExceptionReturn(e.Code, e.Message);
			}
		}
	}
}
