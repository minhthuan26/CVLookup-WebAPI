using CVLookup_WebAPI.Models.Domain;
using FirstWebApi.Models.Database;

namespace CVLookup_WebAPI.Services.JobAddressService
{
	public class JobAddressService : IJobAddressService
	{
		private readonly ILogger _logger;
		private readonly AppDBContext _dbContext;

		public JobAddressService(ILogger logger, AppDBContext dbContext)
		{
			_logger = logger;
			_dbContext = dbContext;
		}
		public Task<List<JobAddress>> WorkAddressList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public Task<JobAddress> Add(JobAddress workAddress)
		{
			throw new NotImplementedException();
		}

		public Task<JobAddress> Delete(string Id)
		{
			throw new NotImplementedException();
		}

		public Task<JobAddress> GetAccountById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<JobAddress> Update(string Id, JobAddress newWorkAddress)
		{
			throw new NotImplementedException();
		}
	}
}
