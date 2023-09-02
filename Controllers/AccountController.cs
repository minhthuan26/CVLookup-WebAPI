using CVLookup_WebAPI.Services.AccountService;
using CVLookup_WebAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CVLookup_WebAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly ILogger<AccountController> _logger;
		private readonly IAccountService _accountService;

		public AccountController(ILogger<AccountController> logger, IAccountService accountService)
		{
			_logger = logger;
			_accountService = accountService;
		}

		[HttpGet()]
		public async Task<IActionResult> getAccountList()
		{
			try
			{
				var accountList = await _accountService.AccountList();
				return Ok(new ApiResponse
				{
					Success = true,
					Message = "Success",
					Data =	accountList,
					Code = StatusCodes.Status200OK
				});
			} catch (Exception e)
			{
				return Ok(new ApiResponse
				{
					Success = false,
					Message = e.Message,
				});
			}
		}
	}
}
