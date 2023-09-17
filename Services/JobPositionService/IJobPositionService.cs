using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;

namespace CVLookup_WebAPI.Services.JobPositionService
{
    public interface IJobPositionService
    {
        public Task<List<JobPosition>> JobPositionList();
		public Task<JobPosition> GetJobPositionById(string id);
		public Task<List<JobPosition>> GetJobPositionsByName(string name);
        public Task<JobPosition> Add(JobPositionVM jobPosition);
        public Task<JobPosition> Update(string Id, JobPositionVM newJobPosition);
        public Task<JobPosition> Delete(string Id);
    }
}
