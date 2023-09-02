using CVLookup_WebAPI.Models.Domain;
using FirstWebApi.Models.Database;

namespace CVLookup_WebAPI.Services.JobFormService
{
	public class JobFormService : IJobFormService
	{
		private readonly ILogger _logger;
		private readonly AppDBContext _dbContext;

		public JobFormService(ILogger logger, AppDBContext dbContext)
		{
			_logger = logger;
			_dbContext = dbContext;
		}
		public Task<List<JobForm>> WorkFormList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public Task<JobForm> Add(JobForm workForm)
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

		public Task<JobForm> Update(string Id, JobForm newWorkForm)
		{
			throw new NotImplementedException();
		}
	}
}
