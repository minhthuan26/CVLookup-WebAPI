using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.AccountService;
using CVLookup_WebAPI.Services.AccountUserService;
using CVLookup_WebAPI.Services.UserService;
using CVLookup_WebAPI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVLookup_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        /// Lấy tất cả thông tin tài khoản
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-account-users")]
        public async Task<IActionResult> GetAccountUserList()
        {
            try
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
            catch (ExceptionReturn ex)
            {
                return Ok(new ApiResponse
                {
                    Success = false,
                    Message = ex.Message,
                    Code = ex.Code
                });
            }
        }
    }
}
