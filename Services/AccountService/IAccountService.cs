using CVLookup_WebAPI.Models.Domain;

namespace CVLookup_WebAPI.Services.AccountService
{
    public interface IAcountService
    {
        public Task<List<Account>> AccountList();
        public Task<Account> GetAccountById(int id);
        public Task<Account> Add(Account account);
        public Task<Account> Update(string Id, Account newAccount);
        public Task<Account> Delete(string Id);
    }
}
