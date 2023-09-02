using CVLookup_WebAPI.Models.Domain;
using FirstWebApi.Models.Database;

namespace CVLookup_WebAPI.Services.RecruitmentService
{
	public class RecruitmentService : IRecruitmentService
	{
		private readonly AppDBContext _dbContext;

		public RecruitmentService(AppDBContext dbContext)
		{
			_dbContext = dbContext;
		}
		public Task<List<Recruitment>> RecruitmentList()
		{
			throw new NotImplementedException();
		}

		public Task<Recruitment> Add(Recruitment recruitment)
		{
			throw new NotImplementedException();
		}

		public Task<Recruitment> Delete(string Id)
		{
			throw new NotImplementedException();
		}

		public Task<Recruitment> GetAccountById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Recruitment> Update(string Id, Recruitment newRecruitment)
		{
			throw new NotImplementedException();
		}
	}
}
