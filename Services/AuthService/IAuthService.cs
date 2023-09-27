using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
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
		public Task Logout ();

		public Task<string> GenerateToken(string key, ListDictionary data, DateTime expires);
		public Task<JwtSecurityToken> ValidateToken(string token, string key);
	}
}
