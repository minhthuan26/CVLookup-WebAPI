using CVLookup_WebAPI.Middleware;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.NotificationService;
using CVLookup_WebAPI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVLookup_WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }


        [HttpPost("add-notification")]
        [MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
        [Authorization("Employer", "Admin", "Candidate")]
        public async Task<IActionResult> Add(NotificationVM notification)
        {
            var result = await _notificationService.Add(notification);
            return Ok(new ApiResponse
            {
                Code = StatusCodes.Status200OK,
                Success = true,
                Data = result,
                Message = "Hoàn thành"
            });
        }

        [HttpGet("get-notification-by-user-id")]
        [MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
        [Authorization("Employer", "Admin", "Candidate")]
        public async Task<IActionResult> GetNotification_ByUserId([FromQuery]string userId)
        {
            var result = await _notificationService.GetNotification_ByUserId(userId);
            return Ok(new ApiResponse
            {
                Code = StatusCodes.Status200OK,
                Success = true,
                Data = result,
                Message = "Hoàn thành"
            });
        }
    }
}
