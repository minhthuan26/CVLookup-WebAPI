using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Utilities;
using System.Collections.Specialized;
using System.IdentityModel.Tokens.Jwt;

namespace CVLookup_WebAPI.Services.AuthService
{
	public interface IAuthService
	{
		public Task<object> Login(AccountVM accountVM);
		public Task<AccountUser> RegisterCandidate(CandidateVM candidateVM, AccountVM account);
		public Task<AccountUser> RegisterEmployer(EmployerVM employerVM, AccountVM account);
		public Task<object> RenewToken();
		public Task<object> Logout();
		public Task<object> ActiveAccount(string activeToken);
		public Task<string> GetCurrentRefreshToken();
		public Task<string> GetCurrentAccessToken();
		public Task<User> GetCurrentLoginUser();
		public Task RestoreRefreshToken(string userId, string connectionId);
	}
}
