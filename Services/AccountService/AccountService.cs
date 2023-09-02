using CVLookup_WebAPI.Models.Domain;
using FirstWebApi.Models.Database;

namespace CVLookup_WebAPI.Services.AccountService
{
    public class AccountService : IAcountService
    {
        private readonly AppDBContext _dbContext;
        private readonly ILogger _logger;

        public AccountService(ILogger logger, AppDBContext dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task<List<Account>> AccountList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task<Account> Add(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<Account> Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetAccountById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Account> Update(string Id, Account newAccount)
        {
            throw new NotImplementedException();
        }
    }
}
