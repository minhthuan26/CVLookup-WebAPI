using CVLookup_WebAPI.Models.Domain;
using FirstWebApi.Models.Database;

namespace CVLookup_WebAPI.Services.JobAddressService
{
	public class JobAddressService : IJobAddressService
	{
		private readonly AppDBContext _dbContext;

		public JobAddressService(AppDBContext dbContext)
		{
			_dbContext = dbContext;
		}
		public Task<List<JobAddress>> JobAddressList()
		{
			throw new NotImplementedException();
		}

		public Task<JobAddress> Add(JobAddress jobAddress)
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

		public Task<JobAddress> Update(string Id, JobAddress newJobAddress)
		{
			throw new NotImplementedException();
		}
	}
}
