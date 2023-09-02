using CVLookup_WebAPI.Models.Domain;
using FirstWebApi.Models.Database;

namespace CVLookup_WebAPI.Services.JobFormService
{
	public class JobFormService : IJobFormService
	{
		private readonly AppDBContext _dbContext;

		public JobFormService(AppDBContext dbContext)
		{
			_dbContext = dbContext;
		}
		public Task<List<JobForm>> JobFormList()
		{
			throw new NotImplementedException();
		}

		public Task<JobForm> Add(JobForm jobForm)
		{
			throw new NotImplementedException();
		}

		public Task<JobForm> Delete(string Id)
		{
			throw new NotImplementedException();
		}

		public Task<JobForm> GetAccountById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<JobForm> Update(string Id, JobForm newJobForm)
		{
			throw new NotImplementedException();
		}
	}
}
