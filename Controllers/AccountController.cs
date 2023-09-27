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
		public async Task<IActionResult> GetAccountList()
		{
			try
			{
				var accounts = await _accountService.AccountList();
				return Ok(new ApiResponse
				{
					Success = true,
					Code = StatusCodes.Status200OK,
					Message = "Hoàn thành",
					Data = accounts
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

		/// <summary>
		/// Lấy Account theo ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("get-account-by-id")]
		public async Task<IActionResult> GetAccountById([FromQuery] string id)
		{
			try
			{
				var account = await _accountService.GetAccountById(id);
				return Ok(new ApiResponse
				{
					Success = true,
					Code = StatusCodes.Status200OK,
					Message = "Hoàn thành",
					Data = account
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

		/// <summary>
		/// Lấy Account theo Email
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		[HttpGet("get-account-by-email")]
		public async Task<IActionResult> GetAccountByEmail([FromQuery] string email)
		{
			try
			{
				var account = await _accountService.GetAccountByEmail(email);
				return Ok(new ApiResponse
				{
					Success = true,
					Code = StatusCodes.Status200OK,
					Message = "Hoàn thành",
					Data = account
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

		/// <summary>
		/// Thêm account
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		[HttpPost("create-account")]
		public async Task<IActionResult> AddAccount([FromBody] AccountVM account)
		{
			try
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
			catch (ExceptionReturn ex)
			{
				return Ok(new ApiResponse { Success = false, Message = ex.Message, Code = StatusCodes.Status500InternalServerError });
			}
		}

		/// <summary>
		/// Sửa Account
		/// </summary>
		/// <param name="id"></param>
		/// <param name="updatedAccount"></param>
		/// <returns></returns>
		[HttpPut("edit-account")]
		public async Task<IActionResult> UpdateAccount([FromQuery] string id, [FromBody] AccountVM updatedAccount)
		{
			try
			{
				var account = await _accountService.Update(id, updatedAccount);
				return Ok(new ApiResponse
				{
					Success = true,
					Code = StatusCodes.Status200OK,
					Message = "Hoàn thành",
					Data = account
				});
			}
			catch (ExceptionReturn ex)
			{
				return Ok(new ApiResponse { Success = false, Message = ex.Message, Code = StatusCodes.Status500InternalServerError });
			}
		}

		/// <summary>
		/// Xoá Account
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete("delete-account")]
		public async Task<IActionResult> DeleteAccount([FromQuery] string id)
		{
			try
			{
				var deletedAccount = await _accountService.Delete(id);
				return Ok(new ApiResponse { Success = true, Code = StatusCodes.Status200OK, Message = "Hoàn thành", Data = deletedAccount });
			}
			catch (ExceptionReturn ex)
			{
				return Ok(new ApiResponse { Success = false, Message = ex.Message, Code = StatusCodes.Status500InternalServerError });
			}
		}
	}
}
