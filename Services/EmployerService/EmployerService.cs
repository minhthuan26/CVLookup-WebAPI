using CVLookup_WebAPI.Models.Domain;
using FirstWebApi.Models.Database;

namespace CVLookup_WebAPI.Services.EmployerService
{
	public class EmployerService : IEmployerService
	{
		private readonly ILogger _logger;
		private readonly AppDBContext _dbContext;

		public EmployerService(ILogger logger, AppDBContext dbContext)
		{
			_logger = logger;
			_dbContext = dbContext;
		}
		public Task<List<Employer>> EmployerList()
		{
			throw new NotImplementedException();
		}

		public Task<Employer> Add(Employer employer)
		{
			throw new NotImplementedException();
		}

		public Task<Employer> Delete(string Id)
		{
			throw new NotImplementedException();
		}

		public Task<Employer> GetAccountById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Employer> Update(string Id, Employer newEmployer)
		{
			throw new NotImplementedException();
		}
	}
}
