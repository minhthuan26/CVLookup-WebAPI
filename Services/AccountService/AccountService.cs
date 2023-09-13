using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace CVLookup_WebAPI.Services.AccountService
{
	public class AccountService : IAccountService
	{
		private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;

        public AccountService(AppDBContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public async Task<List<AccountVM>> AccountList()
		{
			try
			{
				var result = await _dbContext.Account.ToListAsync();
				if (result != null)
				{
                    return _mapper.Map<List<AccountVM>>(result);

                }
                return null;
			}
			catch (Exception e)
			{
                throw new ExceptionReturn(500, e.Message);
            }
		}

		public async Task<AccountVM> Add(AccountVM accountVM)
		{
            try
            {
                var account = _mapper.Map<Account>(accountVM);
                var accountExisted = await _dbContext.Account.Where(prop => prop.Email == account.Email).FirstOrDefaultAsync();
                if (accountExisted != null)
                {
                    throw new ExceptionReturn(400, "Thất bại. Email đã tồn tại!");
                }
                var result = await _dbContext.Account.AddAsync(account);
                if (result.State.ToString() == "Added")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return _mapper.Map<AccountVM>(account);
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

		public async Task<AccountVM> Delete(string Id)
		{
            try
            {
                if (Id == null)
                {
                    throw new ExceptionReturn(400, "Thất bại. Truy vấn không hợp lệ");
                }

                var account = await _dbContext.Account.Where(prop => prop.Id == Id).FirstOrDefaultAsync();
                if (account == null)
                {
                    throw new ExceptionReturn(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }

                var result = _dbContext.Account.Remove(account);
                if (result.State.ToString() == "Deleted")
                {
                    var saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return _mapper.Map<AccountVM>(account);
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

		public async Task<AccountVM> GetAccountByEmail(string email)
		{
            try
            {
                if (email == null)
                {
                    throw new ExceptionReturn(400, "Thất bại. Truy vấn không hợp lệ");
                }

                var result = await _dbContext.Account.Where(prop => prop.Email == email).FirstOrDefaultAsync();
                if (result == null)
                {
                    throw new ExceptionReturn(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }
                return _mapper.Map<AccountVM>(result);
            }
            catch (ExceptionReturn e)
            {
                throw new ExceptionReturn(e.Code, e.Message);
            }
        }

		public async Task<AccountVM> GetAccountById(string id)
		{
            try
            {
                if (id == null)
                {
                    throw new ExceptionReturn(400, "Thất bại. Truy vấn không hợp lệ");
                }

                var result = await _dbContext.Account.Where(prop => prop.Id == id).FirstOrDefaultAsync();
                if (result == null)
                {
                    throw new ExceptionReturn(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }
                return _mapper.Map<AccountVM>(result);
            }
            catch (ExceptionReturn e)
            {
                throw new ExceptionReturn(e.Code, e.Message);
            }
            throw new NotImplementedException();
		}

		public async Task<AccountVM> Update(string Id, AccountVM newAccount)
		{
            try
            {
                var account = await _dbContext.Account.Where(prop => prop.Id == Id).FirstOrDefaultAsync();
                if (account == null)
                {
                    throw new ExceptionReturn(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }
                account.Password = newAccount.Password;
                account.Email = newAccount.Email;
                account.Status = newAccount.Status;
                account.IssuedAt = newAccount.IssuedAt;
                account.ActivedAt = newAccount.ActivedAt;
                account.UpdatedAt = newAccount.UpdatedAt;
                var result = _dbContext.Account.Update(account);
                if (result.State.ToString() == "Modified")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return _mapper.Map<AccountVM>(account);
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
