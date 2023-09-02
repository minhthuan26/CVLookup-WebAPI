using CVLookup_WebAPI.Models.Domain;
using FirstWebApi.Models.Database;

namespace CVLookup_WebAPI.Services.RoleService
{
	public class RoleService : IRoleService
	{
		private readonly ILogger _logger;
		private readonly AppDBContext _dbContext;

		public RoleService(ILogger logger, AppDBContext dbContext)
		{
			_logger = logger;
			_dbContext = dbContext;
		}
		public Task<List<Role>> RoleList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public Task<Role> Add(Role role)
		{
			throw new NotImplementedException();
		}

		public Task<Role> Delete(string Id)
		{
			throw new NotImplementedException();
		}

		public Task<Role> GetAccountById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Role> Update(string Id, Role newAccount)
		{
			throw new NotImplementedException();
		}
	}
}
