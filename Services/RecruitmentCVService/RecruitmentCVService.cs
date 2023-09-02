using CVLookup_WebAPI.Models.Domain;
using FirstWebApi.Models.Database;

namespace CVLookup_WebAPI.Services.RecruitmentCVService
{
	public class RecruitmentCVService : IRecruitmentCVService
	{
		private readonly AppDBContext _dbContext;

		public RecruitmentCVService(AppDBContext dbContext)
		{
			_dbContext = dbContext;
		}
		public Task<List<RecruitmentCV>> RecruitmentCVList()
		{
			throw new NotImplementedException();
		}

		public Task<RecruitmentCV> Add(RecruitmentCV recruitmentCV)
		{
			throw new NotImplementedException();
		}

		public Task<RecruitmentCV> Delete(string Id)
		{
			throw new NotImplementedException();
		}

		public Task<RecruitmentCV> GetAccountById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<RecruitmentCV> Update(string Id, RecruitmentCV newRecruitmentCV)
		{
			throw new NotImplementedException();
		}
	}
}
