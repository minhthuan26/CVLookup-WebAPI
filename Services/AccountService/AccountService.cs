using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

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

        public async Task<List<Account>> AccountList()
        {
            try
            {
                var result = await _dbContext.Account.ToListAsync();
                return result;
            }
            catch (ExceptionReturn e)
            {
                throw new ExceptionReturn(e.Code, e.Message);
            }
        }

        public async Task<Account> Add(AccountVM accountVM)
        {
            try
            {
                var accountExisted = await _dbContext.Account.Where(prop => prop.Email == accountVM.Email).FirstOrDefaultAsync();
                if (accountExisted != null)
                {
                    throw new ExceptionReturn(400, "Thất bại. Email đã tồn tại!");
                }

                var passwordHash = HashPassword(accountVM.Password);
                accountVM.Password = passwordHash;

                var account = _mapper.Map<Account>(accountVM);
                var result = await _dbContext.Account.AddAsync(account);
                if (result.State.ToString() == "Added")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return account;
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

        public async Task<Account> Delete(string Id)
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
                    return account;
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

        public async Task<Account> GetAccountByEmail(string email)
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
                return result;
            }
            catch (ExceptionReturn e)
            {
                throw new ExceptionReturn(e.Code, e.Message);
            }
        }

        public async Task<Account> GetAccountById(string id)
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
                return result;
            }
            catch (ExceptionReturn e)
            {
                throw new ExceptionReturn(e.Code, e.Message);
            }
            throw new NotImplementedException();
        }

        public async Task<Account> Update(string Id, AccountVM newAccountVM)
        {
            try
            {
                var accountInDB = await _dbContext.Account.Where(prop => prop.Id == Id).FirstOrDefaultAsync();
                if (accountInDB == null)
                {
                    throw new ExceptionReturn(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }
                 _mapper.Map(newAccountVM, accountInDB);
                var result = _dbContext.Account.Update(accountInDB);
                if (result.State.ToString() == "Modified")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return accountInDB;
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


        private string HashPassword(string password)
        {
            byte[] saltBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }

            using (var hmac = new HMACSHA512(saltBytes))
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] saltedPassword = hmac.ComputeHash(passwordBytes);
                byte[] combinedBytes = new byte[saltBytes.Length + saltedPassword.Length];
                Buffer.BlockCopy(saltBytes, 0, combinedBytes, 0, saltBytes.Length);
                Buffer.BlockCopy(saltedPassword, 0, combinedBytes, saltBytes.Length, saltedPassword.Length);

                string hashedPassword = Convert.ToBase64String(combinedBytes);

                return hashedPassword;
            }
        }

        
    }
}

