using CVLookup_WebAPI.Models.Domain;

namespace CVLookup_WebAPI.Services.JobCareerService
{
    public interface IJobCareerService
    {
        public Task<List<JobCareer>> WorkCareerList { get; set; }
        public Task<JobCareer> GetAccountById(int id);
        public Task<JobCareer> Add(JobCareer workCareer);
        public Task<JobCareer> Update(string Id, JobCareer newWorkCareer);
        public Task<JobCareer> Delete(string Id);
    }
}
