using CVLookup_WebAPI.Models.Domain;
using FirstWebApi.Models.Database;

namespace CVLookup_WebAPI.Services.AccountUserService
{
    public class AccountUserService : IAccountUserService
    {
        private readonly AppDBContext _dbContext;
        private readonly ILogger _logger;

        public AccountUserService(ILogger logger, AppDBContext dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public Task<List<AccountUser>> AccountUserList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
