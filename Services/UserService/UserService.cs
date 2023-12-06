using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.FileService;
using CVLookup_WebAPI.Services.UserRoleService;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace CVLookup_WebAPI.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUserRoleService _userRoleService;
        private readonly IFileService _fileService;

        public UserService(AppDBContext dbContext, IMapper mapper, IUserRoleService userRoleService, IFileService fileService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userRoleService = userRoleService;
            _fileService = fileService;
        }

        public async Task<User> AddCandidate(CandidateVM candidateVM)
        {
            try
            {
                var candidate = _mapper.Map<Candidate>(candidateVM);
                var userExisted = await _dbContext.User.Where(prop => prop.Email == candidate.Email).FirstOrDefaultAsync();
                if (userExisted != null)
                {
                    throw new ExceptionModel(400, "Email này đã được sử dụng bởi 1 tài khoản khác");
                }

                if (candidateVM.Avatar != null)
                {
                    string uploadPath = "App_Data\\Storage\\" + candidate.Email + "\\Avatar";
                    string filePath = await _fileService.UploadFile(candidateVM.Avatar, uploadPath);
                    candidate.Avatar = filePath;
                }


                var result = await _dbContext.User.AddAsync(candidate);
                if (result.State.ToString() == "Added")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return candidate;
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

        public async Task<User> AddEmployer(EmployerVM employerVM)
        {
            try
            {
                var employer = _mapper.Map<Employer>(employerVM);
                var userExisted = await _dbContext.User.Where(prop => prop.Email == employer.Email).FirstOrDefaultAsync();
                if (userExisted != null)
                {
                    throw new ExceptionModel(400, "Email này đã được sử dụng bởi 1 tài khoản khác");
                }
                if (employerVM.Avatar != null)
                {
                    string uploadPath = "App_Data\\Storage\\" + employer.Email + "\\Avatar";
                    string filePath = await _fileService.UploadFile(employerVM.Avatar, uploadPath);
                    employer.Avatar = filePath;
                }
                var result = await _dbContext.User.AddAsync(employer);
                if (result.State.ToString() == "Added")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return employer;
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

        public async Task<User> Delete(string Id)
        {
            try
            {
                if (Id == null)
                {
                    throw new ExceptionModel(400, "Thất bại. Truy vấn không hợp lệ");
                }
                var user = await _dbContext.User.Where(prop => prop.Id == Id).FirstOrDefaultAsync();
                if (user == null)
                {
                    throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }
                var result = _dbContext.User.Remove(user);
                if (result.State.ToString() == "Deleted")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return user;
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

        public async Task<List<Candidate>> GetCandidatesByName(string name)
        {
            try
            {
                var candidateList = await _dbContext.Candidate.Where(prop => (prop.Username).Contains(name)).ToListAsync();
                return candidateList;
            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }
        }

        public async Task<List<Employer>> GetEmployersByName(string name)
        {
            try
            {
                var employerList = await _dbContext.Employer.Where(prop => prop.Username.Contains(name)).ToListAsync();
                return employerList;
            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            try
            {
                if (email == null)
                {
                    throw new ExceptionModel(400, "Thất bại. Truy vấn không hợp lệ");
                }

                var user = await _dbContext.User.Where(prop => prop.Email == email).FirstOrDefaultAsync();
                if (user == null)
                {
                    throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }
                var userRole = await _userRoleService.GetByUserId(user.Id);
                if (userRole.Role.RoleName == "Employer")
                {
                    return await _dbContext.Employer.Where(prop => prop.Email == email).FirstOrDefaultAsync();
                }
                else if (userRole.Role.RoleName == "Candidate")
                {
                    return await _dbContext.Candidate.Where(prop => prop.Id == email).FirstOrDefaultAsync();
                }
                else
                {
                    return await _dbContext.User.Where(prop => prop.Id == email).FirstOrDefaultAsync();
                }
            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }
        }

        public async Task<object> GetUserById(string id)
        {
            try
            {
                if (id == null)
                {
                    throw new ExceptionModel(400, "Thất bại. Truy vấn không hợp lệ");
                }

                var userRole = await _userRoleService.GetByUserId(id);

                if (userRole.Role.RoleName == "Employer")
                {
                    return await _dbContext.Employer.Where(prop => prop.Id == id).FirstOrDefaultAsync();
                }
                else if (userRole.Role.RoleName == "Candidate")
                {
                    return await _dbContext.Candidate.Where(prop => prop.Id == id).FirstOrDefaultAsync();
                }
                else
                {
                    return await _dbContext.User.Where(prop => prop.Id == id).FirstOrDefaultAsync();
                }
            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }
        }

        public async Task<Candidate> UpdateCandidate(string id, CandidateVM newCandidateVM)
        {
            try
            {
                if (id == null)
                {
                    throw new ExceptionModel(400, "Thất bại. Truy vấn không hợp lệ");
                }
                var candidate = await _dbContext.Candidate.Where(prop => prop.Id == id).FirstOrDefaultAsync();
                if (candidate == null)
                {
                    throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }
                var newCandidate = _mapper.Map<Candidate>(newCandidateVM);
                candidate = newCandidate;
                var resutl = _dbContext.Candidate.Update(candidate);
                if (resutl.State.ToString() == "Modified")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return candidate;
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

        public async Task<Employer> UpdateEmployer(string id, EmployerVM newEmployerVM)
        {
            try
            {
                if (id == null)
                {
                    throw new ExceptionModel(400, "Thất bại. Truy vấn không hợp lệ");
                }
                var employer = await _dbContext.Employer.Where(prop => prop.Id == id).FirstOrDefaultAsync();
                if (employer == null)
                {
                    throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }
                var newEmployer = _mapper.Map<Employer>(newEmployerVM);
                employer = newEmployer;
                var resutl = _dbContext.Employer.Update(employer);
                if (resutl.State.ToString() == "Modified")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return employer;
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

        public async Task<UserListVM> UserList()
        {
            try
            {
                var candidates = await _dbContext.Candidate.ToListAsync();
                var employers = await _dbContext.Employer.ToListAsync();
                var userList = new UserListVM
                {
                    Candidate = candidates,
                    Employer = employers
                };

                return userList;
            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }
        }
    }
}
