using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;

namespace CVLookup_WebAPI.Services.ExperienceService
{
    public interface IExperienceService
    {
        public Task<List<Experience>> ExperienceList();
		public Task<Experience> GetExperienceById(string id);
		public Task<List<Experience>> GetExperiencesByValue(string value);
        public Task<Experience> Add(ExperienceVM experience);
        public Task<Experience> Update(string Id, ExperienceVM newExperience);
        public Task<Experience> Delete(string Id);

    }
}
