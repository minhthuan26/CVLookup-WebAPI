using CVLookup_WebAPI.Services.JobAddressService;
using CVLookup_WebAPI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVLookup_WebAPI.Controllers
{
	[Route("api/v1/[controller]/[action]")]
	[ApiController]
	public class JobAddressController : ControllerBase
	{
		private readonly IJobAddressService _jobAddressService;
		private readonly ILogger<JobAddressController> _logger;

		public JobAddressController(ILogger<JobAddressController> logger, IJobAddressService jobAddressService)
		{
			_jobAddressService = jobAddressService;
			_logger = logger;
		}

		[HttpGet]
		public async Task<IActionResult> getAllJobAddress()
		{
			try
			{
				var result = await _jobAddressService.JobAddressList();
				return Ok(new ApiResponse
				{
					Code = StatusCodes.Status200OK,
					Success = true,
					Data = result,
					Message = "Get job address list successful"
				});
			} catch (Exception e)
			{
				return Ok(new ApiResponse
				{
					Success = false,
					Message = e.Message,
					Code = StatusCodes.Status500InternalServerError
				});
			}
		}

		//[HttpGet]
		//public async Task<IActionResult> getJobAddress([FromQuery] String id)
		//{
		//	try
		//	{

		//	} catch (Exception e)
		//	{
		//		return Ok(new ApiResponse
		//		{

		//		});
		//	}
		//}
	}
}
