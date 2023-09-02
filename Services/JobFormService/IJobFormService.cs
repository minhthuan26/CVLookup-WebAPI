using CVLookup_WebAPI.Models.Domain;

namespace CVLookup_WebAPI.Services.JobFormService
{
    public interface IJobFormService
    {
        public Task<List<JobForm>> JobFormList();
		public Task<JobForm> GetAccountById(int id);
        public Task<JobForm> Add(JobForm jobForm);
        public Task<JobForm> Update(string Id, JobForm newJobForm);
        public Task<JobForm> Delete(string Id);
    }
}
