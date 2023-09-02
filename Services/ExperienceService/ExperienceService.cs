using CVLookup_WebAPI.Models.Domain;
using FirstWebApi.Models.Database;

namespace CVLookup_WebAPI.Services.ExperienceService
{
	public class ExperienceService : IExperienceService
	{
		private readonly ILogger _logger;
		private readonly AppDBContext _dbContext;

		public ExperienceService(ILogger logger, AppDBContext dbContext)
		{
			_logger = logger;
			_dbContext = dbContext;
		}
		public Task<List<Experience>> ExperienceList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public Task<Experience> Add(Experience experience)
		{
			throw new NotImplementedException();
		}

		public Task<Experience> Delete(string Id)
		{
			throw new NotImplementedException();
		}

		public Task<Experience> GetAccountById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Experience> Update(string Id, Experience newExperience)
		{
			throw new NotImplementedException();
		}
	}
}
