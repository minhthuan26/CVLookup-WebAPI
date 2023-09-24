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
                var accountUser = await _dbContext.AccountUser.Include(x => x.Account).Include(x => x.User).ToListAsync();
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

        public async Task<AccountUser> GetByAccountId(string accountId)
        {
            try
            {
                var result = await _dbContext.AccountUser.Where(prop => prop.AccountID == accountId).FirstOrDefaultAsync();
                if (result == null)
                {
                    throw new ExceptionReturn(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }
                return result;
            } catch (ExceptionReturn e)
            {
                throw new ExceptionReturn(e.Code, e.Message);
            }
        }

		public async Task<AccountUser> GetByUserId(string userId)
		{
			try
			{
				var result = await _dbContext.AccountUser.Where(prop => prop.UserId == userId).FirstOrDefaultAsync();
				if (result == null)
				{
					throw new ExceptionReturn(404, "Thất bại. Không thể tìm thấy dữ liệu");
				}
				return result;
			}
			catch (ExceptionReturn e)
			{
				throw new ExceptionReturn(e.Code, e.Message);
			}
		}

		public Task<AccountUser> Update(string Id, RoleVM newAccount)
        {
            throw new NotImplementedException();
        }
    }
}
