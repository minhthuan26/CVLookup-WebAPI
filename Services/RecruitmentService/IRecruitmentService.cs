using CVLookup_WebAPI.Models.Domain;

namespace CVLookup_WebAPI.Services.RecruitmentService
{
    public interface IRecruitmentService
    {
        public Task<List<Recruitment>> RecruitmentList();
		public Task<Recruitment> GetAccountById(int id);
        public Task<Recruitment> Add(Recruitment recruitment);
        public Task<Recruitment> Update(string Id, Recruitment newRecruitment);
        public Task<Recruitment> Delete(string Id);
    }
}
