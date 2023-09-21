using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;

namespace CVLookup_WebAPI.Services.AuthService
{
	public interface IAuthService
	{
		public Task<AuthVM> Login(AccountVM loginVM);
		public Task<AccountUser> RegisterCandidate(CandidateVM candidateVM, AccountVM account);
		public Task<AccountUser> RegisterEmployer(EmployerVM employerVM, AccountVM account);
	}
}
