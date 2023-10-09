using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;

namespace CVLookup_WebAPI.Services.RecruitmentService
{
    public interface IRecruitmentService
    {
        public Task<List<Recruitment>> RecruitmentList();
		public Task<Recruitment> GetRecruitmentById(string id);
		public Task<List<Recruitment>> GetRecruitmentsByTitle(string title);
		public Task<List<Recruitment>> GetRecruitmentsByUserId(string id);
        public Task<Recruitment> Add(RecruitmentVM recruitment);
        public Task<Recruitment> Update(string Id, RecruitmentVM newRecruitment);
        public Task<Recruitment> Delete(string Id);
    }
}
