using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;

namespace CVLookup_WebAPI.Services.AccountService
{
    public interface IAccountService
    {
        public Task<object> AccountList();
        public Task<Account> GetAccountById(string id);
        public Task<Account> GetAccountByEmail(string email);
        public Task<Account> Add(AccountVM account);
        public Task<Account> Update(string Id, AccountVM newAccount);
        public Task<Account> Delete(string Id);
        public Task<Account> ActiveAccount(string Id);
    }
}
