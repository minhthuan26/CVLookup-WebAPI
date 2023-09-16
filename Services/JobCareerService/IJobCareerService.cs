using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;

namespace CVLookup_WebAPI.Services.JobCareerService
{
    public interface IJobCareerService
    {
        public Task<List<JobCareer>> JobCareerList();
		public Task<JobCareer> GetJobCareerById(string id);
		public Task<JobCareer> GetJobCareerByName(string name);
        public Task<JobCareer> Add(JobCareerVM jobCareer);
        public Task<JobCareer> Update(string Id, JobCareerVM newJobCareer);
        public Task<JobCareer> Delete(string Id);
    }
}
