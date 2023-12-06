using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace CVLookup_WebAPI.Services.SignalRService
{
    public class NotificationHub : Hub
    {
        private readonly AppDBContext _dbContext;
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationHub(AppDBContext dbContext, IHubContext<NotificationHub> hubContext)
        {
            _dbContext = dbContext;
            _hubContext = hubContext;
        }

        public async Task SendNotificationToAll(string message)
        {
            try
            {
                await _hubContext.Clients.All.SendAsync("GeneralNotification", message);
            }
            catch (Exception e)
            {
                throw new ExceptionModel(500, e.Message);
            }
        }

        public async Task SendNotificationToClient(string message, string userId)
        {
            try
            {
                var hubConnections = await _dbContext.HubConnection.Where(prop => prop.UserId == userId).ToListAsync();
                if (hubConnections.Count != 0)
                {
                    foreach (HubConnection hubConnection in hubConnections)
                    {
                        await _hubContext.Clients.Client(hubConnection.ConnectionId).SendAsync("ClientNotify", message, userId);
                    }
                }

            }
            catch (Exception e)
            {
                throw new ExceptionModel(500, "Không thể gửi thông báo đến người dùng");
            }
        }

        public override Task OnConnectedAsync()
        {
            //Clients.Caller.SendAsync("ClientConnected", Context.ConnectionId);

            return base.OnConnectedAsync();
        }

        public async Task<string> AddHubConnection(string userId)
        {
            try
            {
                var connectionId = Context.ConnectionId;
                HubConnection hubConnection = new HubConnection
                {
                    ConnectionId = connectionId,
                    UserId = userId
                };
                var oldConnection = await _dbContext.HubConnection.Where(prop => prop.UserId == userId).ToListAsync();
                if (oldConnection.Count != 0)
                {
                    _dbContext.HubConnection.RemoveRange(oldConnection);
                }
                var result = await _dbContext.HubConnection.AddAsync(hubConnection);
                if (result.State.ToString() == "Added")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return connectionId;
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

        public async Task DeleteHubConnectionByConnectionId()
        {
            try
            {
                var connectionId = Context.ConnectionId;
                var hubConnection = await _dbContext.HubConnection.FirstOrDefaultAsync(prop => prop.ConnectionId == connectionId);

                if (hubConnection == null)
                {
                    throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }

                var result = _dbContext.HubConnection.Remove(hubConnection);
                if (result.State.ToString() == "Deleted")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
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

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var hubConnection = _dbContext.HubConnection.FirstOrDefault(prop => prop.ConnectionId == Context.ConnectionId);
            if (hubConnection != null)
            {
                _dbContext.HubConnection.Remove(hubConnection);
                _dbContext.SaveChangesAsync();
            }

            return base.OnDisconnectedAsync(exception);
        }

        public async Task<Notification> AddNotification(string senderId, User receiverUser, string message, RecruitmentCV recruitmentCV)
        {
            try
            {
                Notification notification = new Notification
                {
                    SenderId = senderId,
                    User = receiverUser,
                    Message = message,
                    UserId = receiverUser.Id,
                    RecruitmentCV = recruitmentCV
                };

                var result = await _dbContext.Notification.AddAsync(notification);
                if (result.State.ToString() == "Added")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return notification;
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
    }
}
