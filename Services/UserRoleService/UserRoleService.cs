using CVLookup_WebAPI.Models.Domain;
using FirstWebApi.Models.Database;

namespace CVLookup_WebAPI.Services.UserRoleService
{
	public class UserRoleService : IUserRoleService
	{
		private readonly ILogger _logger;
		private readonly AppDBContext _dbContext;

		public UserRoleService(ILogger logger, AppDBContext dbContext)
		{
			_logger = logger;
			_dbContext = dbContext;
		}
		public Task<List<UserRole>> UserRoleList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public Task<UserRole> Add(UserRole userRole)
		{
			throw new NotImplementedException();
		}

		public Task<UserRole> Delete(string Id)
		{
			throw new NotImplementedException();
		}

		public Task<UserRole> GetAccountById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<UserRole> Update(string Id, UserRole newUserRole)
		{
			throw new NotImplementedException();
		}
	}
}
