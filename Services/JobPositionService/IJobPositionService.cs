using CVLookup_WebAPI.Models.Domain;

namespace CVLookup_WebAPI.Services.JobPositionService
{
    public interface IJobPositionService
    {
        public Task<List<JobPosition>> JobPositionList();
		public Task<JobPosition> GetAccountById(int id);
        public Task<JobPosition> Add(JobPosition jobPosition);
        public Task<JobPosition> Update(string Id, JobPosition newJobPosition);
        public Task<JobPosition> Delete(string Id);
    }
}
