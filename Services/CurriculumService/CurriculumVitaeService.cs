using CVLookup_WebAPI.Models.Domain;
using FirstWebApi.Models.Database;

namespace CVLookup_WebAPI.Services.CurriculumService
{
	public class CurriculumVitaeService : ICurriculumViateService
	{
		private AppDBContext _dbContext;

		public CurriculumVitaeService(AppDBContext dbContext)
		{
			_dbContext = dbContext;
		}
		public Task<List<CurriculumVitae>> CurriculumVitaeList()
		{
			throw new NotImplementedException();
		}

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
