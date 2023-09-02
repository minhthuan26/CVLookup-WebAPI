using CVLookup_WebAPI.Models.Domain;

namespace CVLookup_WebAPI.Services.RecruitmentCVService
{
    public interface IRecruitmentCVService
    {
        public Task<List<RecruitmentCV>> RecruitmentCVList { get; set; }
        public Task<RecruitmentCV> GetAccountById(int id);
        public Task<RecruitmentCV> Add(RecruitmentCV recruitmentCV);
        public Task<RecruitmentCV> Update(string Id, RecruitmentCV newRecruitmentCV);
        public Task<RecruitmentCV> Delete(string Id);
    }
}
