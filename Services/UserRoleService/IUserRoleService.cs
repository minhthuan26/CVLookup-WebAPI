using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;

namespace CVLookup_WebAPI.Services.UserRoleService
{
    public interface IUserRoleService
    {
        public Task<List<UserRole>> UserRoleList();
		public Task<UserRole> GetByUserId(string userId);
		public Task<UserRole> GetByRoleId(string releId);
        public Task<UserRole> Add(UserRoleVM userRole);
        public Task<UserRole> Update(string Id, UserRoleVM newUserRole);
        public Task<UserRole> Delete(string userId, string roleId);
        public Task<List<UserRole>> GetByRoleName(string roleName);

    }
}
