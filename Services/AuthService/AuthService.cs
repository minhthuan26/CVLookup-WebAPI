using AutoMapper;
using CVLookup_WebAPI.Models.ViewModel;
using FirstWebApi.Models.Database;

namespace CVLookup_WebAPI.Services.AuthService
{
	public class AuthService : IAuthService
	{
		private readonly AppDBContext _dbContext;
		private readonly IMapper _mapper;

		public AuthService(AppDBContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}
		public async Task<AuthVM> Login(string email, string password)
		{
			//check login trong Account
			//đúng ->get thông tin và trả về authVM
			throw new NotImplementedException();
		}

		public async Task<AccountUserVM> Register(UserVM user, AccountVM account, string role /*nếu là NTD->employer gán cứng từ controller, nếu là UV -> candidate*/)
		{
			//check tồn tại
			//chưa tồn tại -> tạo user = new candidate hoặc new employer tuỳ vào role
			throw new NotImplementedException();
		}
	}
}
