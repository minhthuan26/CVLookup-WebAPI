using CVLookup_WebAPI.Models.Domain;

namespace CVLookup_WebAPI.Services.EmployerService
{
    public interface IEmployerService
    {
        public Task<List<Employer>> EmployerList { get; set; }
        public Task<Employer> GetAccountById(int id);
        public Task<Employer> Add(Employer employer);
        public Task<Employer> Update(string Id, Employer newEmployer);
        public Task<Employer> Delete(string Id);
    }
}
