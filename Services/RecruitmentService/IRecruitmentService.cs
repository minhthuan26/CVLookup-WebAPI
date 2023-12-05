using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Utilities;

namespace CVLookup_WebAPI.Services.RecruitmentService
{
    public interface IRecruitmentService
    {
        public Task<List<Recruitment>> RecruitmentList();
        public Task<object> GetRecruitment(Filter filter);
		public Task<object> GetRecruitmentById(string id);
		public Task<List<Recruitment>> GetRecruitmentsByTitle(string title);
		public Task<List<Recruitment>> GetRecruitmentsByUserId(string id);
        public Task<Recruitment> Add(RecruitmentVM recruitment);
        public Task<Recruitment> Update(string Id, RecruitmentVM newRecruitment);
        public Task<Recruitment> Delete(string Id);
        public Task<object> UpdateIsExpired(string id);
    }
}
