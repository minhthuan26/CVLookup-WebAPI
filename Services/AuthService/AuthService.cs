using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.AccountService;
using CVLookup_WebAPI.Services.AccountUserService;
using CVLookup_WebAPI.Services.JwtService;
using CVLookup_WebAPI.Services.MailService;
using CVLookup_WebAPI.Services.RefreshTokenService;
using CVLookup_WebAPI.Services.RoleService;
using CVLookup_WebAPI.Services.SignalRService;
using CVLookup_WebAPI.Services.UserRoleService;
using CVLookup_WebAPI.Services.UserService;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MimeKit;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;

namespace CVLookup_WebAPI.Services.AuthService
{
	public class AuthService : IAuthService
	{
		private readonly AppDBContext _dbContext;
		private readonly IAccountService _accountService;
		private readonly IUserService _userService;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IUserRoleService _userRoleService;
		private readonly ITokenService _tokenService;
		private readonly IAccountUserService _accountUserService;
		private readonly IConfiguration _configuration;
		private readonly IRoleService _roleService;
		private readonly IMailService _mailService;
		private readonly IWebHostEnvironment _env;
		private readonly IJwtService _jwtService;
		private readonly IHubContext<NotificationHub> _notificationHub;

		public AuthService(
			AppDBContext dbContext,
			IHttpContextAccessor httpContextAccessor,
			IAccountService accountService,
			IUserService userService,
			IUserRoleService userRoleService,
			ITokenService tokenService,
			IAccountUserService accountUserService,
			IConfiguration configuration,
			IRoleService roleService,
			IMailService mailService,
			IWebHostEnvironment env,
			IJwtService jwtService,
			IHubContext<NotificationHub> notificationHub
			)
		{
			_dbContext = dbContext;
			_accountService = accountService;
			_userService = userService;
			_httpContextAccessor = httpContextAccessor;
			_userRoleService = userRoleService;
			_tokenService = tokenService;
			_accountUserService = accountUserService;
			_configuration = configuration;
			_roleService = roleService;
			_mailService = mailService;
			_env = env;
			_jwtService = jwtService;
			_notificationHub = notificationHub;
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
						throw new ExceptionModel(400, "Thất bại. Tài khoản của bạn chưa được kích hoạt, vui lòng kiểm tra email để kích hoạt tài khoản");
					}
					bool checkPassword = VerifyPasswordHash(accountVM.Password, account.Password);
					if (checkPassword)
					{
						var accountUser = await _accountUserService.GetByAccountId(account.Id);
						var userRole = await _userRoleService.GetByUserId(accountUser.UserId);

						var claims = new ListDictionary();
						claims.Add("accountId", account.Id);
						claims.Add("userId", userRole.UserId);
						claims.Add("role", userRole.Role.RoleName);

						string accessToken = await _jwtService.GenerateToken(_jwtService.GetSecretKey(), claims, DateTime.Now.AddMinutes(10));
						string refreshToken = await _jwtService.GenerateToken(_jwtService.GetRefreshKey(), claims, DateTime.Now.AddDays(7));

						var currentUser = await _userService.GetUserById(accountUser.UserId);
						var authReturn = new
						{
							accessToken = accessToken,
							refreshToken = refreshToken,
							user = currentUser,
							accountId = account.Id,
							role = userRole.Role.RoleName
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
							SameSite = SameSiteMode.Strict,
							Path = "/"
						};
						_httpContextAccessor.HttpContext.Response.Cookies.Append("RefreshToken", refreshToken, cookieOptions);
						//await _notificationHub.AddHubConnection(currentUser);
						await transaction.CommitAsync();
						return authReturn;
					}
					else
					{
						throw new ExceptionModel(400, "Thất bại. Email hoặc mật khẩu không đúng");
					}
				}
				else
				{
					throw new ExceptionModel(404, "Thất bại. Email hoặc mật khẩu không đúng");
				}
			}
			catch (ExceptionModel e)
			{
				await transaction.RollbackAsync();
				throw new ExceptionModel(e.Code, e.Message);
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
			catch (ExceptionModel e)
			{
				throw new ExceptionModel(e.Code, e.Message);
			}
		}
		#endregion

		public async Task<object> RenewToken()
		{
			IDbContextTransaction transaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				string accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
				string refreshToken = _httpContextAccessor.HttpContext.Request.Cookies["RefreshToken"];

				if (string.IsNullOrEmpty(accessToken) || string.IsNullOrEmpty(refreshToken))
				{
					throw new ExceptionModel(400, "Thất bại. Không tìm thấy token");
				}

				accessToken = accessToken.Split(" ")[1];
				VerifyTokenResult accessTokenVerified = await _jwtService.VerifyToken(accessToken, _jwtService.GetSecretKey());
				if (!accessTokenVerified.IsValid)
				{
					throw new ExceptionModel(400, "Thất bại. Token không hợp lệ");
				}
				if (!accessTokenVerified.IsExpired)
				{
					throw new ExceptionModel(400, "Thất bại. Không thể tạo mới token vì token cũ vẫn chưa hết hạn");
				}

				var tokenInDB = await _tokenService.GetTokenByValue(refreshToken);
				VerifyTokenResult refreshTokenVerified = await _jwtService.VerifyToken(tokenInDB.RefreshToken, _jwtService.GetRefreshKey());
				if (!refreshTokenVerified.IsValid)
				{
					throw new ExceptionModel(400, "Thất bại. Token không hợp lệ");
				}
				if (refreshTokenVerified.IsExpired)
				{
					throw new ExceptionModel(400, "Thất bại. Không thể tạo mới token vì refresh token hết hạn, vui lòng đăng nhập lại");
				}

				var claims = new ListDictionary();
				claims.Add("accountId", tokenInDB.AccountId);
				claims.Add("userId", tokenInDB.UserId);
				claims.Add("role", tokenInDB.Role.RoleName);

				var newAccessToken = await _jwtService.GenerateToken(_jwtService.GetSecretKey(), claims, DateTime.Now.AddMinutes(10));
				var newRefreshToken = await _jwtService.GenerateToken(_jwtService.GetRefreshKey(), claims, DateTime.Now.AddDays(7));

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
			catch (ExceptionModel e)
			{
				await transaction.RollbackAsync();
				throw new ExceptionModel(e.Code, e.Message);
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
					Role = role,
					User = newCandidate
				};
				await _userRoleService.Add(userRoleVM);

				var newAccountUserVM = new AccountUserVM
				{
					Account = newAccount,
					User = newCandidate
				};
				var result = await _accountUserService.Add(newAccountUserVM);

				await SendMailToActiveAccount(newAccount);
				await transaction.CommitAsync();
				return result;
			}
			catch (ExceptionModel e)
			{
				await transaction.RollbackAsync();
				throw new ExceptionModel(e.Code, e.Message);
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
					Account = newAccount,
					User = newCandidate
				};
				var result = await _accountUserService.Add(newAccountUserVM);
				await SendMailToActiveAccount(newAccount);
				await transaction.CommitAsync();
				return result;
			}
			catch (ExceptionModel e)
			{
				await transaction.RollbackAsync();
				throw new ExceptionModel(e.Code, e.Message);
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
				string activeToken = await _jwtService.GenerateToken(_jwtService.GetMailKey(), claims, DateTime.Now.AddDays(7));
				string activeLink = appHost + ":" + appPort + "/api/v1/auth/active-account?token=" + activeToken;
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
			catch (ExceptionModel e)
			{
				throw new ExceptionModel(e.Code, e.Message);
			}
			catch (Exception e)
			{
				throw new ExceptionModel(500, e.Message);
			}
		}

		public async Task<object> Logout()
		{
			IDbContextTransaction transaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				string accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];

				if (string.IsNullOrEmpty(accessToken))
				{
					throw new ExceptionModel(400, "Thất bại. Không tìm thấy token");
				}
				VerifyTokenResult verifyTokenResult = await _jwtService.VerifyToken(accessToken.Split(" ")[1], _jwtService.GetSecretKey());
				ListDictionary claims = await _jwtService.GetTokenClaims(verifyTokenResult);
				await _tokenService.DeleteRefreshToken((string)claims["userId"], (string)claims["accountId"]);
				_httpContextAccessor.HttpContext.Response.Cookies.Delete("RefreshToken");
				//await _notificationHub.
				await transaction.CommitAsync();
				return true;
			}
			catch (ExceptionModel e)
			{
				await transaction.RollbackAsync();
				throw new ExceptionModel(e.Code, e.Message);
			}
		}

		public async Task<object> ActiveAccount(string activeToken)
		{
			IDbContextTransaction transaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				if (string.IsNullOrEmpty(activeToken))
				{
					throw new ExceptionModel(400, "Thất bại. Token không hợp lệ");
				}

				_jwtService.VerifyToken(activeToken, _jwtService.GetMailKey());

				VerifyTokenResult tokenVerified = await _jwtService.VerifyToken(activeToken, _jwtService.GetMailKey());
				if (tokenVerified.IsExpired)
				{
					throw new ExceptionModel(400, "Thất bại. Token đã hết hạn, bạn đã không kích hoạt tài khoản trong vòng 7 ngày. Để sử dụng dịch vụ của CVLookup vui lòng đăng kí lại và nhận email kích hoạt tài khoản");
				}
				if (!tokenVerified.IsValid)
				{
					throw new ExceptionModel(400, "Thất bại. Token không hợp lệ");
				}
				string accountId = tokenVerified.Token.Claims.FirstOrDefault(prop => prop.Type == "AccountId").Value;

				var result = await _accountService.ActiveAccount(accountId);

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
			catch (ExceptionModel e)
			{
				await transaction.RollbackAsync();
				throw new ExceptionModel(e.Code, e.Message);
			}
		}

		public async Task<string> GetCurrentRefreshToken()
		{
			try
			{
				var refreshToken = _httpContextAccessor.HttpContext.Request.Cookies["RefreshToken"];
				if (refreshToken == null)
				{
					throw new ExceptionModel(404, "Thất bại. Không tìm thấy token, có thể bạn chưa đăng nhập");
				}
				return refreshToken;
			}
			catch (ExceptionModel e)
			{
				throw new ExceptionModel(e.Code, e.Message);
			}
		}

		public async Task<string> GetCurrentAccessToken()
		{
			try
			{
				string accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
				if (string.IsNullOrEmpty(accessToken) || !accessToken.StartsWith("Bearer"))
				{
					throw new ExceptionModel(404, "Thất bại. Không tìm thấy token, có thể bạn chưa đăng nhập");
				}
				return accessToken.Split(" ")[1];
			}
			catch (ExceptionModel e)
			{
				throw new ExceptionModel(e.Code, e.Message);
			}
		}

		public async Task<User> GetCurrentLoginUser()
		{
			try
			{
				string accessToken = await GetCurrentAccessToken();
				VerifyTokenResult tokenResult = await _jwtService.VerifyToken(accessToken, _jwtService.GetSecretKey());
				ListDictionary claims = await _jwtService.GetTokenClaims(tokenResult);
				if (claims == null)
				{
					throw new ExceptionModel(400, "Thất bại. Token không hợp lệ");
				}
				var user = await _userService.GetUserById((string)claims["userId"]);

				return user;
			}
			catch (ExceptionModel e)
			{
				throw new ExceptionModel(e.Code, e.Message);
			}
		}

		public async Task RestoreRefreshToken(string userId, string connectionId)
		{
			try
			{
				var refreshTokenInDb = await _dbContext.Token.FirstOrDefaultAsync(prop => prop.UserId == userId);
				if (refreshTokenInDb == null)
				{
					await _notificationHub.Clients.Client(connectionId).SendAsync("ForceLogout");
				}
				else
				{
					var cookieOptions = new CookieOptions
					{
						HttpOnly = true,
						Secure = false,
						SameSite = SameSiteMode.Strict,
						Path = "/"
					};

					_httpContextAccessor.HttpContext.Response.Cookies.Append("RefreshToken", refreshTokenInDb.RefreshToken, cookieOptions);
				}

			}
			catch (Exception e)
			{
				throw new ExceptionModel(500, e.Message);
			}

		}
	}
}
