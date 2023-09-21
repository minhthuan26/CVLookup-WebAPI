using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;

namespace CVLookup_WebAPI.Services.RoleService
{
    public interface IRoleService
    {
        public Task<List<Role>> RoleList();
        public Task<Role> GetRoleById(string id);
        public Task<Role> Add(RoleVM role);
        public Task<Role> Update(string Id, RoleVM newAccount);
        public Task<Role> Delete(string Id);
    }
}
