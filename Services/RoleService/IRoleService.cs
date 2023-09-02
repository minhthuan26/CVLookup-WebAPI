using CVLookup_WebAPI.Models.Domain;

namespace CVLookup_WebAPI.Services.RoleService
{
    public interface IRoleService
    {
        public Task<List<Role>> RoleList { get; set; }
        public Task<Role> GetAccountById(int id);
        public Task<Role> Add(Role role);
        public Task<Role> Update(string Id, Role newAccount);
        public Task<Role> Delete(string Id);
    }
}
