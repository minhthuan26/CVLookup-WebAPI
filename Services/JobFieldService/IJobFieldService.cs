using CVLookup_WebAPI.Models.Domain;

namespace CVLookup_WebAPI.Services.JobFieldService
{
    public interface IJobFieldService
    {
        public Task<List<JobField>> JobFieldList();
		public Task<JobField> GetAccountById(int id);
        public Task<JobField> Add(JobField jobField);
        public Task<JobField> Update(string Id, JobField newJobField);
        public Task<JobField> Delete(string Id);
    }
}
