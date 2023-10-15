using CVLookup_WebAPI.Middleware;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.AccountService;
using CVLookup_WebAPI.Services.AccountUserService;
using CVLookup_WebAPI.Services.UserService;
using CVLookup_WebAPI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVLookup_WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
    [AuthorizationAttribute("Admin")]
    public class AccountUserController : ControllerBase
    {
        private readonly IAccountUserService _accountUserService;
        private readonly ILogger<AccountUserController> _logger;

        public AccountUserController(
            ILogger<AccountUserController> logger,
            IAccountUserService accountUserService)
        {
            _accountUserService = accountUserService;
            _logger = logger;
        }

        /// <summary>
        /// Lấy thông tin AcountUser theo UserId
        /// </summary>
        /// <param name="userId">ID của User</param>
        /// <returns>Thông tin UserRole</returns>
        [HttpGet("get-by-user-id")]
        public async Task<IActionResult> GetByUserId([FromQuery] string userId)
        {
            var result = await _accountUserService.GetByUserId(userId);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Hoàn thành",
                Data = result
            });
        }

        /// <summary>
        /// Lấy thông tin AccountUser theo AcountID
        /// </summary>
        /// <param name="roleId">ID của Role</param>
        /// <returns>Thông tin UserRole</returns>
        [HttpGet("get-by-account-id")]
        public async Task<IActionResult> GetByAccountId([FromQuery] string roleId)
        {
            var result = await _accountUserService.GetByAccountId(roleId);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Hoàn thành",
                Data = result
            });
        }

        /// <summary>
        /// Xóa AccountUser
        /// </summary>
        /// <param name="roleId">ID của Role</param>
        /// <param name="userId">ID của User</param>
        /// <returns>Thông tin UserRole đã xóa</returns>
        [HttpDelete("delete-account-user")]
        public async Task<IActionResult> DeleteAccountUser([FromQuery] string accountId, [FromQuery] string userId)
        {
            var result = await _accountUserService.Delete(accountId, userId);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Hoàn thành",
                Data = result
            });
        }

        /// <summary>
        /// Lấy tất cả thông tin tài khoản
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-account-users")]
        public async Task<IActionResult> GetAccountUserList()
        {
            var accountUsers = await _accountUserService.AccountUserList();
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Hoàn thành",
                Data = accountUsers
            });
        }
    }
}
