using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Utilities;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace CVLookup_WebAPI.Services.CurriculumService
{
    public interface ICurriculumViateService
    {
        public Task<List<CurriculumVitae>> CurriculumVitaeList();
		    public Task<CurriculumVitae> GetCurriculumVitaeById(string id);
        public Task<List<CurriculumVitae>> GetByCandidateId(string candidateId);
        public Task<CurriculumVitae> Add(CurriculumVitaeVM curriculumVitae);
        public Task<CurriculumVitae> Update(string Id, CurriculumVitaeVM newCurriculumVitae);
        public Task<CurriculumVitae> Delete(string Id);
        public Task<FileDownload> DownloadCV(string id);
        public Task<object> GetCurrentUserCVUploaded();
        public Task<object> GenCV();
    }
}
