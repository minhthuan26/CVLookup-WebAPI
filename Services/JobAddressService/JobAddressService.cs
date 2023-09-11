using CVLookup_WebAPI.Models.ViewModel;
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

		public Task<JobAddressVM> Add(JobAddressVM jobAddress)
		{
			throw new NotImplementedException();
		}

		public Task<JobAddressVM> Delete(string Id)
		{
			throw new NotImplementedException();
		}

		public Task<JobAddressVM> GetAccountById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<JobAddressVM>> JobAddressList()
		{
			throw new NotImplementedException();
		}

		public Task<JobAddressVM> Update(string Id, JobAddressVM newJobAddress)
		{
			throw new NotImplementedException();
		}
	}
}
