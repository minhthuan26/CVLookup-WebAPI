using CVLookup_WebAPI.Models.Domain;
using FirstWebApi.Models.Database;

namespace CVLookup_WebAPI.Services.AccountUserService
{
    public class AccountUserService : IAccountUserService
    {
        private readonly AppDBContext _dbContext;

        public AccountUserService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<AccountUser>> AccountUserList()
        {
			throw new NotImplementedException();
		}

		public Task<AccountUser> Add(Role role)
        {
            throw new NotImplementedException();
        }

        public Task<AccountUser> Delete(string accountId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<AccountUser> GetAccountById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AccountUser> Update(string Id, Role newAccount)
        {
            throw new NotImplementedException();
        }
    }
}
