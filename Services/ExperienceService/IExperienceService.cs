using CVLookup_WebAPI.Models.Domain;

namespace CVLookup_WebAPI.Services.ExperienceService
{
    public interface IExperienceService
    {
        public Task<List<Experience>> ExperienceList();
		public Task<Experience> GetAccountById(int id);
        public Task<Experience> Add(Experience experience);
        public Task<Experience> Update(string Id, Experience newExperience);
        public Task<Experience> Delete(string Id);

    }
}
