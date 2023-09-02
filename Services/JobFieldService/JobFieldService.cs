using CVLookup_WebAPI.Models.Domain;
using FirstWebApi.Models.Database;

namespace CVLookup_WebAPI.Services.JobFieldService
{
	public class JobFieldService : IJobFieldService
	{
		private readonly ILogger _logger;
		private readonly AppDBContext _dbContext;

		public JobFieldService(ILogger logger, AppDBContext dbContext)
		{
			_logger = logger;
			_dbContext = dbContext;
		}
		public Task<List<JobField>> JobFieldList()
		{
			throw new NotImplementedException();
		}

		public Task<JobField> Add(JobField jobField)
		{
			throw new NotImplementedException();
		}

		public Task<JobField> Delete(string Id)
		{
			throw new NotImplementedException();
		}

		public Task<JobField> GetAccountById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<JobField> Update(string Id, JobField newJobField)
		{
			throw new NotImplementedException();
		}
	}
}
