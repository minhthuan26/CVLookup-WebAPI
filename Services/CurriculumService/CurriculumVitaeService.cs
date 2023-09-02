using CVLookup_WebAPI.Models.Domain;
using FirstWebApi.Models.Database;

namespace CVLookup_WebAPI.Services.CurriculumService
{
	public class CurriculumVitaeService : ICurriculumViateService
	{
		private ILogger _logger;
		private AppDBContext _dbContext;

		public CurriculumVitaeService(ILogger logger, AppDBContext dbContext)
		{
			_logger = logger;
			_dbContext = dbContext;
		}
		public Task<List<CurriculumVitae>> CurriculumVitaeList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public Task<CurriculumVitae> Add(CurriculumVitae curriculumVitae)
		{
			throw new NotImplementedException();
		}

		public Task<CurriculumVitae> Delete(string Id)
		{
			throw new NotImplementedException();
		}

		public Task<CurriculumVitae> GetAccountById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<CurriculumVitae> Update(string Id, CurriculumVitae newCurriculumVitae)
		{
			throw new NotImplementedException();
		}
	}
}
