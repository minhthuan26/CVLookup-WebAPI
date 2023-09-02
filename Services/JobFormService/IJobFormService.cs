using CVLookup_WebAPI.Models.Domain;

namespace CVLookup_WebAPI.Services.JobFormService
{
    public interface IJobFormService
    {
        public Task<List<JobForm>> WorkFormList { get; set; }
        public Task<JobForm> GetAccountById(int id);
        public Task<JobForm> Add(JobForm workForm);
        public Task<JobForm> Update(string Id, JobForm newWorkForm);
        public Task<JobForm> Delete(string Id);
    }
}
