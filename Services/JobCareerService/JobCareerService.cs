using CVLookup_WebAPI.Models.Domain;
using FirstWebApi.Models.Database;

namespace CVLookup_WebAPI.Services.JobCareerService
{
	public class JobCareerService : IJobCareerService
	{
		private readonly ILogger _logger;
		private readonly AppDBContext _dbContext;

		public JobCareerService(ILogger logger, AppDBContext dbContext)
		{
			_logger = logger;
			_dbContext = dbContext;
		}
		public Task<List<JobCareer>> WorkCareerList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public Task<JobCareer> Add(JobCareer workCareer)
		{
			throw new NotImplementedException();
		}

		public Task<JobCareer> Delete(string Id)
		{
			throw new NotImplementedException();
		}

		public Task<JobCareer> GetAccountById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<JobCareer> Update(string Id, JobCareer newWorkCareer)
		{
			throw new NotImplementedException();
		}
	}
}
