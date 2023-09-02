using CVLookup_WebAPI.Models.Domain;
using FirstWebApi.Models.Database;

namespace CVLookup_WebAPI.Services.CandidateService
{
	public class CandidateService : ICandidateService
	{
		private readonly ILogger _logger;
		private readonly AppDBContext _dbContext;

		public CandidateService(ILogger logger, AppDBContext dbContext)
		{
			_logger = logger;
			_dbContext = dbContext;
		}
		public Task<List<Candidate>> CandidateList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public Task<Candidate> Add(Candidate candidate)
		{
			throw new NotImplementedException();
		}

		public Task<Candidate> Delete(string Id)
		{
			throw new NotImplementedException();
		}

		public Task<Candidate> GetAccountById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Candidate> Update(string Id, Candidate newCandidate)
		{
			throw new NotImplementedException();
		}
	}
}
