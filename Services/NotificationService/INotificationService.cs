using CVLookup_WebAPI.Models.ViewModel;

namespace CVLookup_WebAPI.Services.NotificationService
{
    public interface INotificationService
    {
        public Task<object> GetNotification_ById(string id);
        public Task<object> GetNotification_ByUserId(string userId);
        public Task<object> GetNotification_BySenderId(string senderId);
        public Task<object> Add(NotificationVM notificationVM);
        public Task<object> UpdateViewStatus(string id);
        public Task<object> DeleteNotification(string id);
    }
}
