using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.AuthService;
using CVLookup_WebAPI.Services.CurriculumService;
using CVLookup_WebAPI.Services.NotificationService;
using CVLookup_WebAPI.Services.RecruitmentService;
using CVLookup_WebAPI.Services.SignalRService;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CVLookup_WebAPI.Services.RecruitmentCVService
{
    public class RecruitmentCVService : IRecruitmentCVService
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IRecruitmentService _recruitmentService;
        private readonly ICurriculumViateService _curriculumViateService;
        private readonly IAuthService _authService;
        private readonly INotificationService _notificationService;
        private readonly NotificationHub _notificationHub;

        public RecruitmentCVService(
            AppDBContext dbContext,
            IMapper mapper,
            IRecruitmentService recruitmentService,
            ICurriculumViateService curriculumViateService,
            IAuthService authService,
            INotificationService notificationService,
            NotificationHub notificationHub)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _recruitmentService = recruitmentService;
            _curriculumViateService = curriculumViateService;
            _authService = authService;
            _notificationService = notificationService;
            _notificationHub = notificationHub;
        }

        public async Task<object> ApplyToRecruitment(RecruitmentCVVM recruitmentCVVM)
        {
            IDbContextTransaction transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var currentUser = await _authService.GetCurrentLoginUser();
                var recruitmentCV = _mapper.Map<RecruitmentCV>(recruitmentCVVM);

                if (currentUser != recruitmentCV.CurriculumVitae.User)
                {
                    throw new ExceptionModel(400, "Thất bại. Bạn không có quyền truy cập CV này");
                }

                var result = await _dbContext.RecruitmentCV.AddAsync(recruitmentCV);
                if (result.State.ToString() == "Added")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }

                    NotificationVM notification = new NotificationVM
                    {
                        UserId = recruitmentCV.Recruitment.Employer.Id,
                        SenderId = currentUser.Id,
                        Message = "Ứng viên " + currentUser.Username + " đã gửi CV ứng tuyển cho bạn",
                        RecruitmentId = recruitmentCV.RecruitmentId,
                        CvId = recruitmentCV.CurriculumVitaeId

                    };
                    await _notificationService.Add(notification);
                    await _notificationHub.SendNotificationToClient(notification.Message, recruitmentCV.Recruitment.Employer.Id);
                    await transaction.CommitAsync();
                    return new
                    {
                        recruitment = new
                        {
                            Id = recruitmentCV.RecruitmentId,
                            title = recruitmentCV.Recruitment.JobTitle
                        },
                        curriculumVitae = new
                        {
                            Id = recruitmentCV.CurriculumVitaeId,
                        },
                        user = currentUser,
                        AppliedAt = recruitmentCV.AppliedAt.AsTimeAgo()
                    };
                }
                else
                {
                    throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình thêm dữ liệu");
                }

            }
            catch (ExceptionModel e)
            {
                await transaction.RollbackAsync();
                throw new ExceptionModel(e.Code, e.Message);
            }
        }

        public async Task<RecruitmentCV> Delete(string recruitmentId, string curriculumVitaeId)
        {
            try
            {
                if (recruitmentId == null || curriculumVitaeId == null)
                {
                    throw new ExceptionModel(400, "Thất bại. Truy vấn không hợp lệ");
                }

                var recruitmentCV = await _dbContext.RecruitmentCV.Where(prop => prop.RecruitmentId == recruitmentId && prop.CurriculumVitaeId == curriculumVitaeId).FirstOrDefaultAsync();
                if (recruitmentCV == null)
                {
                    throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }

                var result = _dbContext.RecruitmentCV.Remove(recruitmentCV);
                if (result.State.ToString() == "Deleted")
                {
                    var saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return recruitmentCV;
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

        public async Task<object> GetRecruitmentCVBy_RecruitmentId(string id)
        {
            try
            {
                var result = await _dbContext.RecruitmentCV.Where(prop => prop.RecruitmentId == id)
                    .Include(prop => prop.CurriculumVitae)
                    .Include(prop => prop.Recruitment)
                    .ToListAsync();

                if (result.Count == 0)
                {
                    return result;
                }

                List<CurriculumVitae> cvList = new();
                foreach (var row in result)
                {
                    cvList.Add(row.CurriculumVitae);
                }

                return new
                {
                    Recruitment = result[0].Recruitment,
                    CurriculumVitaes = cvList
                };
            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }
        }

        public async Task<object> GetRecruitmentCVBy_CVId(string id)
        {
            try
            {
                var result = await _dbContext.RecruitmentCV
                    .Where(prop => prop.CurriculumVitaeId == id)
                    .Include(prop => prop.Recruitment)
                    .ThenInclude(prop => prop.Employer)
                    .Include(props => props.CurriculumVitae)
                    .ThenInclude(prop => prop.User)
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

        public async Task<object> GetAllCVApplied(string recruitmentId)
        {
            try
            {
                User currentUser = await _authService.GetCurrentLoginUser();
                var role = await _dbContext.UserRole
                    .Include(prop => prop.Role)
                    .Where(prop => prop.UserId == currentUser.Id)
                    .Select(prop => new
                    {
                        prop.Role.RoleName
                    })
                    .FirstOrDefaultAsync();

                var isRecruitmentBelongToUser = await _dbContext.Recruitment.FirstOrDefaultAsync(prop => prop.Employer.Id == currentUser.Id);
                if (role?.RoleName != "Admin" && isRecruitmentBelongToUser == null)
                {
                    throw new ExceptionModel(400, "Thất bại. Truy cập bị từ chối");
                }
                var result = await _dbContext.RecruitmentCV
                    .Include(prop => prop.CurriculumVitae)
                    .ThenInclude(prop => prop.User)
                    .Where(prop => prop.RecruitmentId == recruitmentId)
                    .OrderBy(prop => prop.AppliedAt)
                    .Select(prop => new
                    {
                        prop.RecruitmentId,
                        prop.CurriculumVitaeId,
                        prop.IsPass,
                        prop.IsView,
                        prop.AppliedAt,
                        prop.CurriculumVitae
                    })
                    .ToListAsync();

                return result;
            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }
        }

        public async Task<object> ReApplyCV(string recruitmentId, string userId, string cvId)
        {
            try
            {
                var recruitmentCv = await _dbContext.RecruitmentCV
                    .Where(prop => prop.RecruitmentId == recruitmentId && prop.CurriculumVitae.User.Id == userId)
                    .Include(prop => prop.Recruitment)
                    .ThenInclude(prop => prop.Employer)
                    .Include(prop => prop.CurriculumVitae)
                    .ThenInclude(prop => prop.User)
                    .FirstOrDefaultAsync();

                var cv = await _dbContext.CurriculumVitae.FirstOrDefaultAsync(prop => prop.Id == cvId);

                var employerNotification = await _dbContext.Notification
                                    .FirstOrDefaultAsync(prop => prop.UserId == recruitmentCv.Recruitment.Employer.Id
                                    && prop.SenderId == userId 
                                    && prop.RecruitmentCV.RecruitmentId == recruitmentId);

                if (recruitmentCv == null || cv == null || employerNotification == null)
                {
                    throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }

                //if(recruitmentCv.IsView)
                //{
                //    var candidateNotification = await _dbContext.Notification
                //                    .FirstOrDefaultAsync(prop => prop.UserId == userId
                //                    && prop.SenderId == recruitmentCv.Recruitment.Employer.Id
                //                    && prop.RecruitmentCV.RecruitmentId == recruitmentId);

                //    if (candidateNotification == null)
                //    {
                //        throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
                //    }
                //    await _notificationService.DeleteNotification(candidateNotification.Id);
                //}

                await _notificationService.DeleteNotification(employerNotification.Id);
                var result = _dbContext.RecruitmentCV.Remove(recruitmentCv);
                if (result.State.ToString() == "Deleted")
                {
                    var saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    var recruitmentCVVM = new RecruitmentCVVM()
                    {
                        RecruitmentId = recruitmentId,
                        CurriculumVitaeId = cvId
                    };

                    var newRecord = await ApplyToRecruitment(recruitmentCVVM);

                    return newRecord;
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

        public async Task<RecruitmentCV> UpdateIsView(string cvId, string recruitmentId)
        {
            IDbContextTransaction transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var recruitmentCV =  await _dbContext.RecruitmentCV
                    .Include(prop => prop.Recruitment)
                    .ThenInclude(prop => prop.Employer)
                    .Include(props => props.CurriculumVitae)
                    .ThenInclude(prop => prop.User)
                    .Where(prop => prop.CurriculumVitae.Id == cvId && prop.RecruitmentId == recruitmentId).FirstOrDefaultAsync();
                if (recruitmentCV == null)
                {
                    throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }
                if (!recruitmentCV.IsView)
                {
                    recruitmentCV.IsView = true;
                    var result = _dbContext.RecruitmentCV.Update(recruitmentCV);
                    if (result.State.ToString() == "Modified")
                    {
                        int saveState = await _dbContext.SaveChangesAsync();
                        if (saveState <= 0)
                        {
                            throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                        }
                        NotificationVM notification = new NotificationVM
                        {
                            UserId = recruitmentCV.CurriculumVitae.User.Id,
                            SenderId = recruitmentCV.Recruitment.Employer.Id,
                            Message = "Nhà tuyển dụng " + recruitmentCV.Recruitment.Employer.Username + " đã xem CV bạn",
                            RecruitmentId = recruitmentCV.RecruitmentId,
                            CvId = recruitmentCV.CurriculumVitaeId

                        };
                        await _notificationService.Add(notification);
                        await _notificationHub.SendNotificationToClient(notification.Message, recruitmentCV.CurriculumVitae.User.Id);
                        await transaction.CommitAsync();
                        return recruitmentCV;
                    }
                    else
                    {
                        throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình cập nhật dữ liệu");
                    }
                }
                return recruitmentCV;
            }
            catch (ExceptionModel e)
            {
                await transaction.RollbackAsync();
                throw new ExceptionModel(e.Code, e.Message);
            }

        }

        public async Task<RecruitmentCV> ToggleIsPass(string cvId, string recruitmentId)
        {
            try
            {
                var recruitmentCV = await _dbContext.RecruitmentCV
                    .Include(prop => prop.Recruitment)
                    .ThenInclude(prop => prop.Employer)
                    .Include(props => props.CurriculumVitae)
                    .ThenInclude(prop => prop.User)
                    .Where(prop => prop.CurriculumVitae.Id == cvId && prop.RecruitmentId == recruitmentId).FirstOrDefaultAsync();
                if (recruitmentCV == null)
                {
                    throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }
                recruitmentCV.IsPass = !recruitmentCV.IsPass;
                var result = _dbContext.RecruitmentCV.Update(recruitmentCV);
                if (result.State.ToString() == "Modified")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return recruitmentCV;

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
        public async Task<object> GetRecruitmentBy_CvId_And_RecruitmentId(string cvId, string recruitmentId)
        {
            try
            {
                var result = await _dbContext.RecruitmentCV
                    .Include(prop => prop.Recruitment)
                    .Include(prop => prop.Recruitment.JobAddress)
                    .Include(prop => prop.Recruitment.JobCareer)
                    .Include(prop => prop.Recruitment.JobField)
                    .Include(prop => prop.Recruitment.Experience)
                    .Include(prop => prop.Recruitment.JobForm)
                    .Include(prop => prop.Recruitment.JobPosition)
                    .Include(props => props.CurriculumVitae)
                    .ThenInclude(prop => prop.User)
                    .Where(prop => prop.CurriculumVitae.Id == cvId && prop.RecruitmentId == recruitmentId).FirstOrDefaultAsync();

                if (result == null)
                {
                    return result;
                }
                else
                {
                    return new
                    {
                        result.Recruitment,
                        result.CurriculumVitae,
                        result.IsPass,
                        result.IsView,
                        AppliedAt = result.AppliedAt.AsTimeAgo()
                    };
                }

            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }
        }

        public async Task<object> GetRecruitmentBy_UserId_And_RecruitmentId(string userId, string recruitmentId)
        {
            try
            {
                var result = await _dbContext.RecruitmentCV
                    .Include(prop => prop.Recruitment)
                    .Include(props => props.CurriculumVitae)
                    .ThenInclude(prop => prop.User)
                    .Where(prop => prop.CurriculumVitae.User.Id == userId && prop.RecruitmentId == recruitmentId).FirstOrDefaultAsync();

                if (result == null)
                {
                    return result;
                }
                else
                {
                    return new
                    {
                        result.RecruitmentId,
                        result.CurriculumVitaeId,
                        result.IsPass,
                        result.IsView,
                        AppliedAt = result.AppliedAt.AsTimeAgo()
                    };
                }

            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }
        }
    }
}
