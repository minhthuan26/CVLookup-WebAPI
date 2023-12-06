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
        public Task<RecruitmentCV> UpdateIsView(string cvId, string recruitmentId);
        public Task<RecruitmentCV> ToggleIsPass(string cvId, string recruitmentId);

        public Task<object> GetRecruitmentCVByIsPass(string id);
        public Task<object> ReApplyCV(string recruitmentId, string userId, string cvId);
        public Task<RecruitmentCV> Delete(string recruitmentId, string curriculumVitaeId);
        public Task<object> GetRecruitmentBy_CvId_And_RecruitmentId (string cvId, string recruitmentId);
        public Task<object> GetRecruitmentBy_UserId_And_RecruitmentId(string userId, string recruitmentId);
    }
}
