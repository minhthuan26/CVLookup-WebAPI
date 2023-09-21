using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.AccountService;
using CVLookup_WebAPI.Services.UserService;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace CVLookup_WebAPI.Services.AccountUserService
{
    public class AccountUserService : IAccountUserService
    {
        private readonly AppDBContext _dbContext;
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;

        public AccountUserService(AppDBContext dbContext, IAccountService accountService, IUserService userService)
        {
            _dbContext = dbContext;
            _accountService = accountService;
            _userService = userService;
        }

        public async Task<List<AccountUser>> AccountUserList()
        {
            try
            {
                var accountUser = await _dbContext.AccountUser.ToListAsync();
                if (accountUser == null)
                {
                    throw new ExceptionReturn(404, "Không tìm thấy dữ liệu.");
                }
                else
                {
                    return accountUser;
                }
            }
            catch (ExceptionReturn e)
            {
                throw new ExceptionReturn(e.Code, e.Message);
            }
        }

        public async Task<AccountUser> Add(AccountUserVM accountUserVM)
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

        public Task<AccountUser> Update(string Id, RoleVM newAccount)
        {
            throw new NotImplementedException();
        }
    }
}
