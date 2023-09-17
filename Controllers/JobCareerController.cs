using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.JobCareerService;
using CVLookup_WebAPI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVLookup_WebAPI.Controllers
{
	[Route("api/v1/[controller]/")]
	[ApiController]
	public class JobCareerController : ControllerBase
	{
		private readonly IJobCareerService _jobCareerService;
		private readonly ILogger<JobCareerController> _logger;

		public JobCareerController(ILogger<JobCareerController> logger, IJobCareerService jobCareerService)
		{
			_jobCareerService = jobCareerService;
			_logger = logger;
		}
		/// <summary>
		/// Lấy tất cả ngành nghề công việc
		/// </summary>
		/// <returns></returns>
		[HttpGet("get-all-job-career")]
		public async Task<IActionResult> getAllCareer()
		{
			try
			{
				var result = await _jobCareerService.JobCareerList();
				return Ok(new ApiResponse
				{
					Code = StatusCodes.Status200OK,
					Success = true,
					Data = result,
					Message = "Hoàn thành"
				});
			}
			catch (Exception e)
			{
				return Ok(new ApiResponse
				{
					Success = false,
					Message = e.Message,
					Code = StatusCodes.Status500InternalServerError
				});
			}
		}

		/// <summary>
		/// Tìm kiếm ngành nghề bằng id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("get-job-career-by-id")]
		public async Task<IActionResult> getCareerById([FromQuery] string id)
		{
			try
			{
				var result = await _jobCareerService.GetJobCareerById(id);
				return Ok(new ApiResponse
				{
					Success = true,
					Code = StatusCodes.Status200OK,
					Data = result,
					Message = "Hoàn thành"
				});
			}
			catch (ExceptionReturn e)
			{
				return Ok(new ApiResponse
				{
					Success = false,
					Code = e.Code,
					Message = e.Message
				});
			}
		}

		/// <summary>
		/// Tìm kiếm ngành nghề bằng tên
		/// </summary>
		/// <param name="address"></param>
		/// <returns></returns>
		[HttpGet("get-job-career-by-name")]
		public async Task<IActionResult> getCareersByName([FromQuery] string address)
		{
			try
			{
				var result = await _jobCareerService.GetJobCareersByName(address);
				return Ok(new ApiResponse
				{
					Success = true,
					Code = StatusCodes.Status200OK,
					Data = result,
					Message = "Hoàn thành"
				});
			}
			catch (ExceptionReturn e)
			{
				return Ok(new ApiResponse
				{
					Success = false,
					Code = e.Code,
					Message = e.Message
				});
			}
		}

		/// <summary>
		/// Thêm ngành nghề công việc mới
		/// </summary>
		/// <param name="jobAddress"></param>
		/// <returns></returns>
		[HttpPost("add-job-career")]
		public async Task<IActionResult> addCareer([FromBody] JobCareerVM jobAddress)
		{
			try
			{
				var result = await _jobCareerService.Add(jobAddress);
				return Ok(new ApiResponse
				{
					Success = true,
					Code = StatusCodes.Status200OK,
					Data = result,
					Message = "Hoàn thành"
				});
			}
			catch (ExceptionReturn e)
			{
				return Ok(new ApiResponse
				{
					Success = false,
					Code = e.Code,
					Message = e.Message
				});
			}
		}

		/// <summary>
		/// Xoá ngành nghề công việc
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete("delete")]
		public async Task<IActionResult> deleteCareer([FromQuery] string id)
		{
			try
			{

				var result = await _jobCareerService.Delete(id);
				return Ok(new ApiResponse
				{
					Success = true,
					Code = StatusCodes.Status200OK,
					Data = result,
					Message = "Hoàn thành"
				});
			}
			catch (ExceptionReturn e)
			{
				return Ok(new ApiResponse
				{
					Success = false,
					Code = e.Code,
					Message = e.Message
				});
			}
		}

		/// <summary>
		/// Cập nhật ngành nghề làm việc
		/// </summary>
		/// <param name="id"></param>
		/// <param name="jobCareerVM"></param>
		/// <returns></returns>
		[HttpPatch("update")]
		public async Task<IActionResult> updateCareer([FromQuery] string id, [FromBody] JobCareerVM jobCareerVM)
		{
			try
			{
				var result = await _jobCareerService.Update(id, jobCareerVM);
				return Ok(new ApiResponse
				{
					Success = true,
					Code = StatusCodes.Status200OK,
					Data = result,
					Message = "Hoàn thành"
				});
			}
			catch (ExceptionReturn e)
			{
				return Ok(new ApiResponse
				{
					Success = false,
					Code = e.Code,
					Message = e.Message
				});
			}
		}

	}
}
