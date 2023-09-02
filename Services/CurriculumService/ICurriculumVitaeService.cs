using CVLookup_WebAPI.Models.Domain;

namespace CVLookup_WebAPI.Services.CurriculumService
{
    public interface ICurriculumViateService
    {
        public Task<List<CurriculumVitae>> CurriculumVitaeList { get; set; }
        public Task<CurriculumVitae> GetAccountById(int id);
        public Task<CurriculumVitae> Add(CurriculumVitae curriculumVitae);
        public Task<CurriculumVitae> Update(string Id, CurriculumVitae newCurriculumVitae);
        public Task<CurriculumVitae> Delete(string Id);
    }
}
