using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.JwtService;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;

namespace CVLookup_WebAPI.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountService(AppDBContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<object> AccountList()
        {
            try
            {
                var admin = await _dbContext.Account.FromSqlRaw(
					"select a.Id, a.Email, a.Actived, a.ActivedAt, a.IssuedAt, a.UpdatedAt, a.Password " +
					"from Account as a " +
					"join AccountUser as au on a.Id = au.AccountId " +
					"join [User] as u on au.UserId = u.Id " +
					"join UserRole as ur on ur.UserId = u.Id " +
					"join Role as r on r.RoleName='Admin' and r.Id=ur.RoleId").ToListAsync();

				var employer = await _dbContext.Account.FromSqlRaw(
				   "select a.Id, a.Email, a.Actived, a.ActivedAt, a.IssuedAt, a.UpdatedAt, a.Password " +
				   "from Account as a " +
				   "join AccountUser as au on a.Id = au.AccountId " +
				   "join [User] as u on au.UserId = u.Id " +
				   "join UserRole as ur on ur.UserId = u.Id " +
				   "join Role as r on r.RoleName='Employer' and r.Id=ur.RoleId").ToListAsync();

				var candidate = await _dbContext.Account.FromSqlRaw(
				   "select a.Id, a.Email, a.Actived, a.ActivedAt, a.IssuedAt, a.UpdatedAt, a.Password " +
				   "from Account as a " +
				   "join AccountUser as au on a.Id = au.AccountId " +
				   "join [User] as u on au.UserId = u.Id " +
				   "join UserRole as ur on ur.UserId = u.Id " +
				   "join Role as r on r.RoleName='Candidate' and r.Id=ur.RoleId").ToListAsync();
                
                var noneUser = await _dbContext.Account.FromSqlRaw(
                    "select a.Id, a.Email, a.Actived, a.ActivedAt, a.IssuedAt, a.UpdatedAt, a.Password " +
					"from Account as a " +
					"where not exists (" +
					"select au.AccountId " +
					"from AccountUser as au " +
					"where au.AccountId = a.Id)"
					).ToListAsync();
				
                return new
                {
                    admin = admin,
                    employer = employer,
                    candidate = candidate,
                    noneUser = noneUser
                };
            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }
        }

        public async Task<Account> ActiveAccount(string Id)
        {
            try
            {
                var account = await GetAccountById(Id);
                if (account.Actived)
                {
                    throw new ExceptionModel(400, "Thất bại. Tài khoản này đã được kích hoạt từ trước");
                }

                account.Actived = true;
                account.UpdatedAt = DateTime.Now;
                account.ActivedAt = account.UpdatedAt;
                var result = _dbContext.Account.Update(account);
                if (result.State.ToString() == "Modified")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return account;
                }
                else
                {
                    throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình kích hoạt tài khoản");
                }
            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }
        }

        public async Task<Account> Add(AccountVM accountVM)
        {
            try
            {
                var accountExisted = await _dbContext.Account.Where(prop => prop.Email == accountVM.Email).FirstOrDefaultAsync();
                if (accountExisted != null)
                {
                    throw new ExceptionModel(400, "Thất bại. Email đã tồn tại!");
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
                        throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return account;
                }
                else
                {
                    throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình thêm dữ liệu");
                }

            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }
        }

        public async Task<Account> Delete(string Id)
        {
            try
            {
                if (Id == null)
                {
                    throw new ExceptionModel(400, "Thất bại. Truy vấn không hợp lệ");
                }

                var account = await _dbContext.Account.Where(prop => prop.Id == Id).FirstOrDefaultAsync();
                if (account == null)
                {
                    throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }

                var result = _dbContext.Account.Remove(account);
                if (result.State.ToString() == "Deleted")
                {
                    var saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return account;
                }
                else
                {
                    throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình xoá dữ liệu");
                }

            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }
        }

        public async Task<Account> GetAccountByEmail(string email)
        {
            try
            {
                if (email == null)
                {
                    throw new ExceptionModel(400, "Thất bại. Truy vấn không hợp lệ");
                }

                var result = await _dbContext.Account.Where(prop => prop.Email == email).FirstOrDefaultAsync();
                if (result == null)
                {
                    throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }
                return result;
            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }
        }

        public async Task<Account> GetAccountById(string id)
        {
            try
            {
                if (id == null)
                {
                    throw new ExceptionModel(400, "Thất bại. Truy vấn không hợp lệ");
                }

                var result = await _dbContext.Account.Where(prop => prop.Id == id).FirstOrDefaultAsync();
                if (result == null)
                {
                    throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }
                return result;
            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }
            throw new NotImplementedException();
        }

        public async Task<Account> Update(string Id, AccountVM newAccountVM)
        {
            try
            {
                var claims = (ListDictionary)_httpContextAccessor.HttpContext.Items["claims"];

                var role = await _dbContext.Role.Where(prop => prop.Id == claims["roleId"]).FirstOrDefaultAsync();
                if (role.RoleName != "Admin" && Id != claims["accountId"])
                {
                    throw new ExceptionModel(400, "Thất bại. Bạn không có quyền truy cập");
                }

                var accountInDB = await _dbContext.Account.Where(prop => prop.Id == Id).FirstOrDefaultAsync();
                if (accountInDB == null)
                {
                    throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }
                _mapper.Map(newAccountVM, accountInDB);
                accountInDB.UpdatedAt = DateTime.Now;
                var result = _dbContext.Account.Update(accountInDB);
                if (result.State.ToString() == "Modified")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return accountInDB;
                }
                else
                {
                    throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình cập nhật dữ liệu");
                }

            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
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

