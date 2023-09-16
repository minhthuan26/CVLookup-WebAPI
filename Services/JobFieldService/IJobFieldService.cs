using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;

namespace CVLookup_WebAPI.Services.JobFieldService
{
    public interface IJobFieldService
    {
        public Task<List<JobField>> JobFieldList();
		public Task<JobField> GetJobFieldById(string id);
		public Task<JobField> GetJobFieldByName(string id);
        public Task<JobField> Add(JobFieldVM jobField);
        public Task<JobField> Update(string Id, JobFieldVM newJobField);
        public Task<JobField> Delete(string Id);
    }
}
