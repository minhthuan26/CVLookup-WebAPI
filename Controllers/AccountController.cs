using CVLookup_WebAPI.Middleware;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.AccountService;
using CVLookup_WebAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CVLookup_WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger, IAccountService accountService)
        {
            _accountService = accountService;
            _logger = logger;
        }
        /// <summary>
        /// Lấy tất cả danh sách account
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-account")]
		[MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
		[Authorization("Admin")]
		public async Task<IActionResult> GetAccountList()
        {
            var result = await _accountService.AccountList();
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Hoàn thành",
                Data = result
            });
        }

        /// <summary>
        /// Lấy Account theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-account-by-id")]
		[MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
		[Authorization("Admin", "Candidate", "Employer")]
		public async Task<IActionResult> GetAccountById([FromQuery] string id)
        {
            var result = await _accountService.GetAccountById(id);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Hoàn thành",
                Data = result
            });
        }

        /// <summary>
        /// Lấy Account theo Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("get-account-by-email")]
		[MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
		[Authorization("Admin")]
		public async Task<IActionResult> GetAccountByEmail([FromQuery] string email)
        {
            var result = await _accountService.GetAccountByEmail(email);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Hoàn thành",
                Data = result
            });
        }

        /// <summary>
        /// Thêm account
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [HttpPost("create-account")]
		[MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
		[Authorization("Admin")]
		public async Task<IActionResult> CreateAccount([FromBody] AccountVM account)
        {
            var newAccount = await _accountService.Add(account);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Hoàn thành",
                Data = newAccount
            });
        }

        /// <summary>
        /// Sửa Account
        /// </summary>
        /// <param name="id"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        [HttpPatch("edit-account")]
		[MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
		[Authorization("Admin", "Employer", "Candidate")]
		public async Task<IActionResult> UpdateAccount([FromQuery] string id, [FromBody] AccountVM account)
        {
            var result = await _accountService.Update(id, account);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Hoàn thành",
                Data = result
            });
        }

        /// <summary>
        /// Xoá Account
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete-account")]
		[MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
		[Authorization("Admin", "Employer", "Candidate")]
		public async Task<IActionResult> DeleteAccount([FromQuery] string id)
        {
            var result = await _accountService.Delete(id);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Hoàn thành",
                Data = result
            });
        }
    }
}
