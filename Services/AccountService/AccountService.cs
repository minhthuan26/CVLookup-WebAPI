using CVLookup_WebAPI.Models.Domain;
using FirstWebApi.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CVLookup_WebAPI.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly AppDBContext _dbContext;

        public AccountService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Account>> AccountList()
        {
			try
            {
                var accountList = await _dbContext.Account.ToListAsync();
                return accountList;
			} catch (Exception e)
            {
                throw new Exception("Somethings went wrong", e);
            }
		}

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
