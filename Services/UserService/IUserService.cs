using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;

namespace CVLookup_WebAPI.Services.UserService
{
    public interface IUserService
    {
        public Task<UserListVM> UserList();
		public Task<object> GetUserById(string id);
		public Task<User> GetUserByEmail(string email);
		public Task<List<Candidate>> GetCandidatesByName(string name);
		public Task<List<Employer>> GetEmployersByName(string name);
        public Task<User> AddCandidate(CandidateVM candidateVM);
        public Task<User> AddEmployer(EmployerVM employerVM);
        public Task<Candidate> UpdateCandidate(string id, CandidateVM newCandidateVM);
        public Task<Employer> UpdateEmployer(string id, EmployerVM newEmployerVM);
        public Task<User> Delete(string Id);
    }
}
