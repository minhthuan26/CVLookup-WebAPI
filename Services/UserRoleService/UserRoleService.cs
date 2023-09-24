using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace CVLookup_WebAPI.Services.UserRoleService
{
	public class UserRoleService : IUserRoleService
	{
		private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;

        public UserRoleService(AppDBContext dbContext, IMapper mapper)
        {
			_dbContext = dbContext; 
            _mapper = mapper;

        }

        public async Task<UserRole> Add(UserRoleVM userRoleVM)
		{
            try
            {
                var userRole = _mapper.Map<UserRole>(userRoleVM);
                var result = await _dbContext.UserRole.AddAsync(userRole);
                if (result.State.ToString() == "Added")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return userRole;
                }
                else
                {
                    throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình thêm dữ liệu");
                }

            }
            catch (ExceptionReturn e)
            {
                throw new ExceptionReturn(e.Code, e.Message);
            }
        }

		public Task<UserRole> Delete(string Id)
		{
			throw new NotImplementedException();
		}

		public async Task<UserRole> GetByUserId(string userId)
		{
			try
			{
				var result = await _dbContext.UserRole.Where(prop => prop.UserId == userId).Include(prop => prop.User).FirstOrDefaultAsync();
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

		public async Task<UserRole> GetByRoleId(string roleId)
		{
			try
			{
				var result = await _dbContext.UserRole.Where(prop => prop.RoleId == roleId).Include(prop => prop.User).FirstOrDefaultAsync();
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

		public Task<UserRole> Update(string Id, UserRoleVM newUserRole)
		{
			throw new NotImplementedException();
		}

		public Task<List<UserRole>> UserRoleList()
		{
			throw new NotImplementedException();
		}
	}
}
