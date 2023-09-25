using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace CVLookup_WebAPI.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;

        public RoleService(AppDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<Role>> RoleList()
        {
            try
            {
                var role = await _dbContext.Role.ToListAsync();
                if (role == null)
                {
                    throw new ExceptionReturn(400, "Không có danh sách.");
                }
                else
                {
                    return role;
                }
            }
            catch (ExceptionReturn e)
            {

                throw new ExceptionReturn(e.Code, e.Message);
            }
        }

        public async Task<Role> Add(RoleVM roleVM)
        {
            try
            {
                var role = _mapper.Map<Role>(roleVM);

                var roleExisted = await _dbContext.Role.Where(prop => prop.RoleName == roleVM.RoleName).FirstOrDefaultAsync();
                if (roleExisted != null)
                {
                    throw new ExceptionReturn(400, "Thất bại. Phân quyền đã tồn tại!");
                }
                var result = await _dbContext.Role.AddAsync(role);
                if (result.State.ToString() == "Added")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return role;
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

        public async Task<Role> Delete(string Id)
        {
            try
            {
                if (Id == null)
                {
                    throw new ExceptionReturn(400, "Thất bại. Truy vấn không hợp lệ");
                }

                var role = await _dbContext.Role.Where(prop => prop.Id == Id).FirstOrDefaultAsync();
                if (role == null)
                {
                    throw new ExceptionReturn(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }

                var result = _dbContext.Role.Remove(role);
                if (result.State.ToString() == "Deleted")
                {
                    var saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return role;
                }
                else
                {
                    throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình xoá dữ liệu");
                }

            }
            catch (ExceptionReturn e)
            {
                throw new ExceptionReturn(e.Code, e.Message);
            }
        }

        public async Task<Role> GetRoleById(string id)
        {
            try
            {
                if (id == null)
                {
                    throw new ExceptionReturn(400, "Thất bại. Truy vấn không hợp lệ");
                }

                var result = await _dbContext.Role.Where(prop => prop.Id == id).FirstOrDefaultAsync();
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

		public async Task<Role> GetRoleByValue(string value)
		{
			try
			{
				var result = await _dbContext.Role.Where(prop => prop.RoleName == value).FirstOrDefaultAsync();
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

		public async Task<Role> Update(string Id, RoleVM newRole)
        {
            try
            {
                var role = await _dbContext.Role.Where(prop => prop.Id == Id).FirstOrDefaultAsync();
                if (role == null)
                {
                    throw new ExceptionReturn(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }
                role.RoleName = newRole.RoleName;
                var result = _dbContext.Role.Update(role);
                if (result.State.ToString() == "Modified")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return role;
                }
                else
                {
                    throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình cập nhật dữ liệu");
                }

            }
            catch (ExceptionReturn e)
            {
                throw new ExceptionReturn(e.Code, e.Message);
            }
        }
    }
}
