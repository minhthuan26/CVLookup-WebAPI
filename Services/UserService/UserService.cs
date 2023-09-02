using CVLookup_WebAPI.Models.Domain;
using FirstWebApi.Models.Database;

namespace CVLookup_WebAPI.Services.UserService
{
	public class UserService : IUserService
	{
		private readonly ILogger _logger;
		private readonly AppDBContext _dbContext;

		public UserService(ILogger logger, AppDBContext dbContext)
		{
			_logger = logger;
			_dbContext = dbContext;
		}
		public Task<List<User>> UserList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public Task<User> Add(User user)
		{
			throw new NotImplementedException();
		}

		public Task<User> Delete(string Id)
		{
			throw new NotImplementedException();
		}

		public Task<User> GetAccountById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<User> Update(string Id, User newUser)
		{
			throw new NotImplementedException();
		}
	}
}
