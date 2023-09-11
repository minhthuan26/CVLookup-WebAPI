using AutoMapper;
using CVLookup_WebAPI.Models.ViewModel;
using FirstWebApi.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace CVLookup_WebAPI.Services.JobAddressService
{
	public class JobAddressService : IJobAddressService
	{
		private readonly AppDBContext _dbContext;
		private readonly IMapper _mapper;

		public JobAddressService(AppDBContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public Task<JobAddressVM> Add(JobAddressVM jobAddress)
		{
			throw new NotImplementedException();
		}

		public Task<JobAddressVM> Delete(string Id)
		{
			throw new NotImplementedException();
		}

		public Task<JobAddressVM> GetJobAddressById(string id)
		{
			//try
			//{
				
			//} catch (Exception e)
			//{
			//	throw new Exception(e.Message);
			//}
			throw new NotImplementedException();
		}

		public async Task<List<JobAddressVM>> JobAddressList()
		{
			try
			{
				var jobAddressList = await _dbContext.JobAddress.ToListAsync();
				return _mapper.Map<List<JobAddressVM>>(jobAddressList);
			} catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public Task<JobAddressVM> Update(string Id, JobAddressVM newJobAddress)
		{
			throw new NotImplementedException();
		}
	}
}
