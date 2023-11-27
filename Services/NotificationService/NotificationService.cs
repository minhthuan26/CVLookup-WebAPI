using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace CVLookup_WebAPI.Services.NotificationService
{
    public class NotificationService : INotificationService
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;

        public NotificationService(AppDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<object> Add(NotificationVM notificationVM)
        {
            try
            {
                var newNotification = _mapper.Map<Notification>(notificationVM);

                var result = await _dbContext.Notification.AddAsync(newNotification);

                if (result.State.ToString() == "Added")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return new
                    {
                        newNotification.Id,
                        newNotification.UserId,
                        newNotification.SenderId,
                        newNotification.Message,
                        newNotification.IsView,
                        newNotification.RecruitmentCV.CurriculumVitaeId,
                        newNotification.RecruitmentCV.RecruitmentId,
                        notifiedAt = newNotification.NotifiedAt.AsTimeAgo(),
                    };
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

        public Task<object> GetNotification_ById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetNotification_BySenderId(string senderId)
        {
            throw new NotImplementedException();
        }

        public async Task<object> GetNotification_ByUserId(string userId)
        {
            try
            {
                var notifications = await _dbContext.Notification
                    .Where(prop => prop.UserId == userId)
                    .Select(prop => new
                    {
                        prop.Id,
                        prop.UserId,
                        prop.SenderId,
                        prop.Message,
                        prop.IsView,
                        prop.RecruitmentCV.CurriculumVitaeId,
                        prop.RecruitmentCV.RecruitmentId,
                        NotifiedAt = prop.NotifiedAt.AsTimeAgo(),
                    }).ToListAsync();
                return notifications;
            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }
        }

        public Task<object> UpdateViewStatus(string id)
        {
            throw new NotImplementedException();
        }
    }
}
