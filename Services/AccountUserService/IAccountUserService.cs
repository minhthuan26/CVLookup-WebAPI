using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;

namespace CVLookup_WebAPI.Services.AccountUserService
{
    public interface IAccountUserService
    {
        public Task<List<AccountUser>> AccountUserList();
        public Task<AccountUser> GetByAccountId(string accountId);
        public Task<AccountUser> GetByUserId(string accountId);
        public Task<AccountUser> Add(AccountUserVM accountUserVM);
        public Task<AccountUser> Update(string Id, AccountUserVM newAccount);
        public Task<AccountUser> Delete(string accountId, string userId);
    }
}
