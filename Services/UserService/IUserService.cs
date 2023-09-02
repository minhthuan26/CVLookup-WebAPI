using CVLookup_WebAPI.Models.Domain;

namespace CVLookup_WebAPI.Services.UserService
{
    public interface IUserService
    {
        public Task<List<User>> UserList();
		public Task<User> GetAccountById(int id);
        public Task<User> Add(User user);
        public Task<User> Update(string Id, User newUser);
        public Task<User> Delete(string Id);
    }
}
