using CVLookup_WebAPI.Models.Domain;

namespace CVLookup_WebAPI.Services.JobFieldService
{
    public interface IJobFieldService
    {
        public Task<List<JobField>> WorkFieldList { get; set; }
        public Task<JobField> GetAccountById(int id);
        public Task<JobField> Add(JobField workField);
        public Task<JobField> Update(string Id, JobField newWorkField);
        public Task<JobField> Delete(string Id);
    }
}
