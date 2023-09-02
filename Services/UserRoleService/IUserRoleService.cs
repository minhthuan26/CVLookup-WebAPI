using CVLookup_WebAPI.Models.Domain;

namespace CVLookup_WebAPI.Services.UserRoleService
{
    public interface IUserRoleService
    {
        public Task<List<UserRole>> UserRoleList { get; set; }
        public Task<UserRole> GetAccountById(int id);
        public Task<UserRole> Add(UserRole userRole);
        public Task<UserRole> Update(string Id, UserRole newUserRole);
        public Task<UserRole> Delete(string Id);
    }
}
