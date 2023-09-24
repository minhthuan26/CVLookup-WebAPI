using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace CVLookup_WebAPI.Services.RefreshTokenService
{
    public class RefreshTokenService : IRefreshTokenService
    {

        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;

        public RefreshTokenService(AppDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<RefreshToken> AddRToken(RefreshToken refresh)
        {
            try
            {
                var result = await _dbContext.RefreshToken.AddAsync(refresh);
                if (result.State.ToString() == "Added")
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
                    throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình thêm dữ liệu");
                }

            }
            catch (ExceptionReturn e)
            {
                throw new ExceptionReturn(e.Code, e.Message);
            }
        }

       public async Task<RefreshToken> DeleteRToken(string id)
        {
            try
            {
                if (id == null)
                {
                    throw new ExceptionReturn(400, "Thất bại. Truy vấn không hợp lệ");
                }

                var refresh = await _dbContext.RefreshToken.Where(prop => prop.UserId == id).FirstOrDefaultAsync();
                if (refresh == null)
                {
                    throw new ExceptionReturn(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }

                var result = _dbContext.RefreshToken.Remove(refresh);
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

        public async Task<RefreshToken> EditRToken(string userId, string accountId, RefreshToken newRefresh)
        {
            try
            {
                var refresh = await _dbContext.RefreshToken.Where(prop => prop.UserId == userId && accountId == prop.AccountId).FirstOrDefaultAsync();
                if (refresh == null)
                {
                    throw new ExceptionReturn(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }

                refresh.Token = newRefresh.Token;
                refresh.CreateAt = newRefresh.CreateAt;
                refresh.ExpiredAt = newRefresh.ExpiredAt;
                var result = _dbContext.RefreshToken.Update(refresh);
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


        public RefreshToken GetToken()
        {
            try
            {
                var result =  _dbContext.RefreshToken.FirstOrDefault();
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
