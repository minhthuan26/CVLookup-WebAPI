using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;

namespace CVLookup_WebAPI.Services.RecruitmentCVService
{
    public interface IRecruitmentCVService
    {
        public Task<List<RecruitmentCV>> RecruitmentCVList();
		public Task<object> GetRecruitmentCVByRecruitmentId(string id);
		public Task<RecruitmentCV> GetRecruitmentCVByCurriculumVitaeId(string id);
        public Task<object> ApplyToRecruitment(RecruitmentCVVM recruitmentCV);
        public Task<RecruitmentCV> Update(string Id, RecruitmentCVVM newRecruitmentCV);
        public Task<RecruitmentCV> Delete(string recruitmentId, string curriculumVitaeId);
    }
}
