using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;

namespace CVLookup_WebAPI.Services.RecruitmentCVService
{
    public interface IRecruitmentCVService
    {
        public Task<object> GetAllCVApplied(string recruitmentId);
		public Task<object> GetRecruitmentCVBy_RecruitmentId(string id);
		public Task<object> GetRecruitmentCVBy_CVId(string id);
        public Task<object> ApplyToRecruitment(RecruitmentCVVM recruitmentCV);
        public Task<RecruitmentCV> UpdateIsView(string Id);
        public Task<RecruitmentCV> ToggleIsPass(string id);

        public Task<object> ReAppplyCV(string recruitmentId, string userId, string cvId);
        public Task<RecruitmentCV> Delete(string recruitmentId, string curriculumVitaeId);
        public Task<object> GetRecruitmentCVByIsPass(string id);

    }
}
