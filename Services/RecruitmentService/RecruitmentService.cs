using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.AuthService;
using CVLookup_WebAPI.Services.UserService;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CVLookup_WebAPI.Services.RecruitmentService
{
    public class RecruitmentService : IRecruitmentService
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthService _authService;

        public RecruitmentService(AppDBContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor, IAuthService authService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _authService = authService;
        }
        public async Task<Recruitment> Add(RecruitmentVM recruitmentVM)
        {
            try
            {
                var user = await _authService.GetCurrentLoginUser();
                var recruitment = _mapper.Map<Recruitment>(recruitmentVM);
                recruitment.Employer = (Employer)user;
                recruitment.CreatedAt = DateTime.Now;
                recruitment.IsExpired = recruitment.CreatedAt > recruitment.ApplicationDeadline;
                recruitment.ApplicationDeadline = recruitment.ApplicationDeadline.AddDays(1);
                var result = await _dbContext.Recruitment.AddAsync(recruitment);
                if (result.State.ToString() == "Added")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return recruitment;
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

        public async Task<Recruitment> Delete(string Id)
        {
            try
            {
                if (Id == null)
                {
                    throw new ExceptionModel(400, "Thất bại. Truy vấn không hợp lệ");
                }

                var recruitment = await _dbContext.Recruitment.Where(prop => prop.Id == Id).FirstOrDefaultAsync();
                if (recruitment == null)
                {
                    throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }

                var result = _dbContext.Recruitment.Remove(recruitment);
                if (result.State.ToString() == "Deleted")
                {
                    var saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return recruitment;
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

        public async Task<object> GetRecruitment(Filter filter)
        {
            try
            {
                var recruitments = _dbContext.Recruitment
                    .Include(prop => prop.JobAddress)
                    .Include(prop => prop.JobAddress.Province)
                    .Include(prop => prop.Employer)
                    .AsQueryable();
                #region Filter
                if (!string.IsNullOrEmpty(filter.Keyword))
                {
                    recruitments = recruitments.Where(prop => prop.JobTitle.Contains(filter.Keyword));
                }

                if (!string.IsNullOrEmpty(filter.Province))
                {
                    recruitments = recruitments.Where(prop => prop.JobAddress.Province.Name.Equals(filter.Province));

                }

                if (!string.IsNullOrEmpty(filter.District))
                {
                    recruitments = recruitments.Where(prop => prop.JobAddress.District.Equals(filter.District));
                }

                if (!string.IsNullOrEmpty(filter.Career))
                {
                    recruitments = recruitments.Where(prop => prop.JobCareer.Career.Equals(filter.Career));
                }

                if (!string.IsNullOrEmpty(filter.UserId))
                {
                    recruitments = recruitments.Where(prop => prop.Employer.Id.Equals(filter.UserId));
                }

                if (!string.IsNullOrEmpty(filter.JobField))
                {
                    recruitments = recruitments.Where(prop => prop.JobField.Field.Equals(filter.JobField));
                }

                if (!string.IsNullOrEmpty(filter.JobForm))
                {
                    recruitments = recruitments.Where(prop => prop.JobForm.Form.Equals(filter.JobForm));
                }

                if (!string.IsNullOrEmpty(filter.Experience))
                {
                    recruitments = recruitments.Where(prop => prop.Experience.Exp.Equals(filter.Experience));
                }

                if (!string.IsNullOrEmpty(filter.Position))
                {
                    recruitments = recruitments.Where(prop => prop.JobPosition.Position.Equals(filter.Position));
                }
                #endregion

                #region Sort
                switch (filter.SortBy)
                {
                    case "title_asc":
                        recruitments = recruitments.OrderBy(prop => prop.JobTitle);
                        break;

                    case "title_desc":
                        recruitments = recruitments.OrderByDescending(prop => prop.JobTitle);
                        break;

                    case "date_asc":
                        recruitments = recruitments.OrderBy(prop => prop.CreatedAt);
                        break;

                    case "date_desc":
                        recruitments = recruitments.OrderByDescending(prop => prop.CreatedAt);
                        break;

                    default:
                        break;
                }
                #endregion

                #region Paging
                //var paging = Pagination<Recruitment>.Create(recruitments, filter.Page, Filter.PageSize);
                #endregion
                var result = recruitments.Select(prop => new
                {
                    prop.Id,
                    prop.JobTitle,
                    User = new
                    {
                        prop.Employer.Id,
                        prop.Employer.Email,
                        prop.Employer.Username,
                        Avatar = prop.Employer.Avatar != null ? Convert.ToBase64String(File.ReadAllBytes(prop.Employer.Avatar)) : null
                    },
                    JobAddress = new
                    {
                        prop.JobAddress.AddressDetail,
                        Province = prop.JobAddress.Province.Name,
                        prop.JobAddress.District
                    },
                    prop.Salary,
                    CreatedAt = prop.CreatedAt.AsTimeAgo()
                });

                return result.ToList();

            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }
            catch (Exception e)
            {
                throw new ExceptionModel(500, e.Message);
            }
        }

        public async Task<object> GetRecruitmentById(string id)
        {
            try
            {
                if (id == null)
                {
                    throw new ExceptionModel(400, "Thất bại. Truy vấn không hợp lệ");
                }

                var updateExpired = await _dbContext.Recruitment.Where(prop => prop.Id == id)
                    .Include(prop => prop.JobAddress)
                    .Include(prop => prop.JobAddress.Province)
                    .Include(prop => prop.JobPosition)
                    .Include(prop => prop.JobForm)
                    .Include(prop => prop.JobField)
                    .Include(prop => prop.Experience)
                    .Include(prop => prop.JobCareer)
                    .Include(prop => prop.Employer)
                    .FirstOrDefaultAsync();

                if (updateExpired == null)
                {
                    throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }

                var isExpired = updateExpired.ApplicationDeadline < DateTime.Now;

                if(isExpired)
                {
                    updateExpired.IsExpired = true;
                    var update = _dbContext.Recruitment.Update(updateExpired);
                    if (update.State.ToString() == "Modified")
                    {
                        int saveState = await _dbContext.SaveChangesAsync();
                        if (saveState <= 0)
                        {
                            throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                        }
                    }
                    else
                    {
                        throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình cập nhật dữ liệu");
                    }
                }

                var result = await _dbContext.Recruitment.Where(prop => prop.Id == id)
                    .Include(prop => prop.JobAddress)
                    .Include(prop => prop.JobAddress.Province)
                    .Include(prop => prop.JobPosition)
                    .Include(prop => prop.JobForm)
                    .Include(prop => prop.JobField)
                    .Include(prop => prop.Experience)
                    .Include(prop => prop.JobCareer)
                    .Include(prop => prop.Employer)
                    .Select(prop => new
                    {
                        prop.Id,
                        prop.JobTitle,
                        User = new
                        {
                            prop.Employer.Address,
                            prop.Employer.Website,
                            prop.Employer.Id,
                            prop.Employer.Email,
                            prop.Employer.Username,
                            Avatar = prop.Employer.Avatar != null ? Convert.ToBase64String(File.ReadAllBytes(prop.Employer.Avatar)) : null
                        },
                        JobAddress = new
                        {
                            prop.JobAddress.AddressDetail,
                            Province = prop.JobAddress.Province.Name,
                            prop.JobAddress.District
                        },
                        prop.JobField,
                        prop.JobForm,
                        prop.JobCareer,
                        prop.JobPosition,
                        prop.Experience,
                        prop.Salary,
                        prop.Quantity,
                        CreatedAt = prop.CreatedAt.AsTimeAgo(),
                        prop.Benefit,
                        prop.JobDescription,
                        prop.JobRequirement,
                        prop.ApplicationDeadline,
                        prop.IsExpired
                    })
                    .FirstOrDefaultAsync();

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

        public async Task<List<Recruitment>> GetRecruitmentsByTitle(string title)
        {
            try
            {
                if (title == null)
                {
                    throw new ExceptionModel(400, "Thất bại. Truy vấn không hợp lệ");
                }

                var result = await _dbContext.Recruitment.Where(prop => prop.JobTitle.Contains(title)).ToListAsync();
                return result;
            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }
        }

        public Task<List<Recruitment>> GetRecruitmentsByUserId(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Recruitment>> RecruitmentList()
        {
            try
            {
                var recruitmentList = await _dbContext.Recruitment.Include(prop => prop.JobAddress)
                    .Include(prop => prop.JobAddress.Province)
                    .Include(prop => prop.JobPosition)
                    .Include(prop => prop.JobForm)
                    .Include(prop => prop.JobField)
                    .Include(prop => prop.Experience)
                    .Include(prop => prop.JobCareer)
                    .Include(prop => prop.Employer).ToListAsync();
                return recruitmentList;
            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(500, e.Message);
            }
        }

        public async Task<Recruitment> Update(string Id, RecruitmentVM newRecruitmentVM)
        {
            try
            {
                var user = await _authService.GetCurrentLoginUser();

                var recruitment = await _dbContext.Recruitment.Where(prop => prop.Id == Id)
                    .Include(prop => prop.JobAddress.Province)
                    .Include(prop => prop.JobPosition)
                    .Include(prop => prop.JobForm)
                    .Include(prop => prop.JobField)
                    .Include(prop => prop.Experience)
                    .Include(prop => prop.JobCareer)
                    .Include(prop => prop.Employer).FirstOrDefaultAsync();


                if (recruitment == null)
                {
                    throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }
                var newrecruitment = _mapper.Map<Recruitment>(newRecruitmentVM);
                newrecruitment.Employer = (Employer) user;
                newrecruitment.CreatedAt = DateTime.Now;
                newrecruitment.IsExpired = newrecruitment.CreatedAt > newrecruitment.ApplicationDeadline;
                //recruitment = newRecuitment;
                var result = _dbContext.Recruitment.Update(newrecruitment);
                if (result.State.ToString() == "Modified")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return recruitment;

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

        public async Task<List<Recruitment>> GetAllByEmployer()
        {
            try
            {
                User currentUser = await _authService.GetCurrentLoginUser();
                var recruitmentList = await _dbContext.Recruitment.Include(prop => prop.JobAddress)
                    .Include(prop => prop.JobAddress.Province)
                    .Include(prop => prop.JobPosition)
                    .Include(prop => prop.JobForm)
                    .Include(prop => prop.JobField)
                    .Include(prop => prop.Experience)
                    .Include(prop => prop.JobCareer)
                    .Include(prop => prop.Employer).Where(prop => prop.Employer == currentUser).ToListAsync();
                return recruitmentList;
            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(500, e.Message);
            }
        }

        public Task<object> UpdateIsExpired(string id)
        {
            throw new NotImplementedException();
        }
    }
}
