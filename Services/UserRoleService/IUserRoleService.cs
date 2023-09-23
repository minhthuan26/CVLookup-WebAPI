using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;

namespace CVLookup_WebAPI.Services.UserRoleService
{
    public interface IUserRoleService
    {
        public Task<List<UserRole>> UserRoleList();
		public Task<UserRole> GetAccountById(int id);
        public Task<UserRole> Add(UserRoleVM userRole);
        public Task<UserRole> Update(string Id, UserRoleVM newUserRole);
        public Task<UserRole> Delete(string Id);
    }
}
