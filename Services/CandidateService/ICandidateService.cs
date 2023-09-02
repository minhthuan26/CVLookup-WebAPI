using CVLookup_WebAPI.Models.Domain;

namespace CVLookup_WebAPI.Services.CandidateService
{
    public interface ICandidateService
    {
        public Task<List<Candidate>> CandidateList { get; set; }
        public Task<Candidate> GetAccountById(int id);
        public Task<Candidate> Add(Candidate candidate);
        public Task<Candidate> Update(string Id, Candidate newCandidate);
        public Task<Candidate> Delete(string Id);
    }
}
