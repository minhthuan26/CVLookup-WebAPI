using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.AccountService;
using CVLookup_WebAPI.Services.UserRoleService;
using CVLookup_WebAPI.Services.UserService;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace CVLookup_WebAPI.Services.AccountUserService
{
    public class AccountUserService : IAccountUserService
    {
        private readonly AppDBContext _dbContext;
        private readonly IUserRoleService _userRoleService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;

        public AccountUserService(AppDBContext dbContext,
                                    IMapper mapper,
                                    IUserRoleService userRoleService,
                                    IUserService userService,
                                    IAccountService accountService)
        {
            _dbContext = dbContext;
            _userRoleService = userRoleService;
            _mapper = mapper;
            _userService = userService;
            _accountService = accountService;
        }

        public async Task<List<AccountUser>> AccountUserList()
        {
            try
            {
                var accountUser = await _dbContext.AccountUser.Include(x => x.Account).Include(x => x.User).ToListAsync();
                if (accountUser == null)
                {
                    throw new ExceptionModel(404, "Không tìm thấy dữ liệu.");
                }
                else
                {
                    return accountUser;
                }
            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }
        }
        public async Task<List<AccountUser>> GetAccountUser_By_RoleName(string roleName)
        {
            try
            {
                var userRoles = await _userRoleService.GetByRoleName(roleName);

                var allAccountUsers = await _dbContext.AccountUser
                    .Include(au => au.Account)
                    .Include(au => au.User)
                    .ToListAsync();

                var filteredAccountUsers = allAccountUsers
                    .Where(au => userRoles.Any(ur => ur.UserId == au.UserId))
                    .ToList();

                if (filteredAccountUsers == null || filteredAccountUsers.Count == 0)
                {
                    throw new ExceptionModel(404, "Không tìm thấy dữ liệu.");
                }
                foreach (var accountUser in filteredAccountUsers)
                {
                    if (accountUser.User != null && accountUser.User.Avatar != null)
                    {
                        accountUser.User.Avatar = Convert.ToBase64String(File.ReadAllBytes(accountUser.User.Avatar));
                    }
                }
                return filteredAccountUsers;
            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }
        }



        public async Task<AccountUser> Add(AccountUserVM accountUserVM)
        {
            try
            {
                var newAccountUser = _mapper.Map<AccountUser>(accountUserVM);
                var accountUserInDB = await _dbContext.AccountUser
                    .Where(prop => prop.UserId == newAccountUser.UserId && prop.AccountId == newAccountUser.AccountId)
                    .FirstOrDefaultAsync();
                if (accountUserInDB != null)
                {
                    throw new ExceptionModel(400, "Thất bại. Tài khoản này đã được đăng kí cho 1 người dùng khác");
                }
                var result = await _dbContext.AccountUser.AddAsync(newAccountUser);
                if (result.State.ToString() == "Added")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return newAccountUser;
                }
                else
                {
                    throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình thêm dữ liệu");
                }

            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }
        }

        public async Task<AccountUser> Delete(string accountId, string userId)
        {
            try
            {
                if (accountId == null || userId == null)
                {
                    throw new ExceptionModel(400, "Thất bại. Truy vấn không hợp lệ");
                }

                var accountUser = await _dbContext.AccountUser.Where(prop => prop.UserId == userId && prop.AccountId == accountId).FirstOrDefaultAsync();
                if (accountUser == null)
                {
                    throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }

                var result = _dbContext.AccountUser.Remove(accountUser);

                if (result.State.ToString() == "Deleted")
                {
                    var saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    await _userService.Delete(userId);
                    await _accountService.Delete(accountId);
                    return accountUser;
                }
                else
                {
                    throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình xoá dữ liệu");
                }

            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }
        }

        public async Task<AccountUser> GetByAccountId(string accountId)
        {
            try
            {
                var result = await _dbContext.AccountUser.Where(prop => prop.AccountId == accountId).FirstOrDefaultAsync();
                if (result == null)
                {
                    throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }
                return result;
            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }
        }

        public async Task<AccountUser> GetByUserId(string userId)
        {
            try
            {
                if (userId==null)
                {
                    throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }
                var result = await _dbContext.AccountUser.Include(prop=>prop.User)
                                                        .Include(prop=>prop.Account)                 
                                                        .Where(prop => prop.UserId == userId).FirstOrDefaultAsync();

                if (result.User.Avatar!=null)
                {
                    result.User.Avatar = Convert.ToBase64String(File.ReadAllBytes(result?.User?.Avatar));

                }
                if (result == null)
                {
                    throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }
                return result;
            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }
        }

        public Task<AccountUser> Update(string Id, AccountUserVM newAccount)
        {
            throw new NotImplementedException();
        }
    }
}
