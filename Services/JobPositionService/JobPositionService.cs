using CVLookup_WebAPI.Models.Domain;
using FirstWebApi.Models.Database;

namespace CVLookup_WebAPI.Services.JobPositionService
{
	public class JobPositionService : IJobPositionService
	{
		private readonly AppDBContext _dbContext;

		public JobPositionService(AppDBContext dbContext)
		{
			_dbContext = dbContext;
		}
		public Task<List<JobPosition>> JobPositionList()
		{
			throw new NotImplementedException();
		}

		public Task<JobPosition> Add(JobPosition jobPosition)
		{
			throw new NotImplementedException();
		}

		public Task<JobPosition> Delete(string Id)
		{
			throw new NotImplementedException();
		}

		public Task<JobPosition> GetAccountById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<JobPosition> Update(string Id, JobPosition newJobPosition)
		{
			throw new NotImplementedException();
		}
	}
}
