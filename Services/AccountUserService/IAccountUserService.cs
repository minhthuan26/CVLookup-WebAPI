using CVLookup_WebAPI.Models.Domain;

namespace CVLookup_WebAPI.Services.AccountUserService
{
    public interface IAccountUserService
    {
        public Task<List<AccountUser>> AccountUserList { get; set; }
        public Task<AccountUser> GetAccountById(int id);
        public Task<AccountUser> Add(Role role);
        public Task<AccountUser> Update(string Id, Role newAccount);
        public Task<AccountUser> Delete(string accountId, string userId);
    }
}
