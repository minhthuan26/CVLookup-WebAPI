using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;

namespace CVLookup_WebAPI.Services.JobFormService
{
    public interface IJobFormService
    {
        public Task<List<JobForm>> JobFormList();
		public Task<JobForm> GetJobFormById(string id);
		public Task<List<JobForm>> GetJobFormsByName(string name);
        public Task<JobForm> Add(JobFormVM jobForm);
        public Task<JobForm> Update(string Id, JobFormVM newJobForm);
        public Task<JobForm> Delete(string Id);
    }
}
