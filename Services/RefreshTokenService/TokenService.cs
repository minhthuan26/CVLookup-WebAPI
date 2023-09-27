using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace CVLookup_WebAPI.Services.RefreshTokenService
{
    public class TokenService : ITokenService
    {

        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;

        public TokenService(AppDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Token> AddRefreshToken(TokenVM tokenVM)
        {
            try
            {
                var refreshToken = _mapper.Map<Token>(tokenVM);
                var result = await _dbContext.Token.AddAsync(refreshToken);
                if (result.State.ToString() == "Added")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return refreshToken;
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
			catch (Exception e)
			{
				throw new ExceptionReturn(500, e.Message);
			}
		}

        public async Task<Token> DeleteRefreshToken(string userId, string accountId)
        {
            try
            {
                if (userId == null || accountId ==null)
                {
                    throw new ExceptionReturn(400, "Thất bại. Truy vấn không hợp lệ");
                }

                var refresh = await _dbContext.Token.Where(prop => prop.UserId == userId && prop.AccountId == accountId).FirstOrDefaultAsync();
                if (refresh == null)
                {
                    throw new ExceptionReturn(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }

                var result = _dbContext.Token.Remove(refresh);
                if (result.State.ToString() == "Deleted")
                {
                    var saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return refresh;
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

        public async Task<Token> EditRefreshToken(TokenVM tokenVM)
        {
            try
            {
                var refresh = await _dbContext.Token.Where(prop => prop.UserId == tokenVM.UserId && tokenVM.AccountId == prop.AccountId).FirstOrDefaultAsync();
                if (refresh == null)
                {
                    throw new ExceptionReturn(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }

                refresh.RefreshToken = tokenVM.RefreshToken;
                var result = _dbContext.Token.Update(refresh);
                if (result.State.ToString() == "Modified")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return refresh;

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


        public async Task<Token> GetTokenById(string userId, string accountId)
        {
            try
            {
                var result = await  _dbContext.Token.Where(prop => prop.UserId == userId && prop.AccountId == accountId).FirstOrDefaultAsync();
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

		public async Task<Token> GetTokenByValue(string token)
		{
			try
			{
				var result = await _dbContext.Token.Where(prop => prop.RefreshToken == token).FirstOrDefaultAsync();
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
	}
}
