using CVLookup_WebAPI.Models.Domain;

namespace CVLookup_WebAPI.Services.JobCareerService
{
    public interface IJobCareerService
    {
        public Task<List<JobCareer>> JobCareerList();
		public Task<JobCareer> GetAccountById(int id);
        public Task<JobCareer> Add(JobCareer jobCareer);
        public Task<JobCareer> Update(string Id, JobCareer newJobCareer);
        public Task<JobCareer> Delete(string Id);
    }
}
