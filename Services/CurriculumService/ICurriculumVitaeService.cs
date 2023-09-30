using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;

namespace CVLookup_WebAPI.Services.CurriculumService
{
    public interface ICurriculumViateService
    {
        public Task<List<CurriculumVitae>> CurriculumVitaeList();
		public Task<CurriculumVitae> GetCurriculumVitaeById(string id);
        public Task<CurriculumVitae> Add(CurriculumVitaeVM curriculumVitae);
        public Task<CurriculumVitae> Update(string Id, CurriculumVitaeVM newCurriculumVitae);
        public Task<CurriculumVitae> Delete(string Id);
    }
}
