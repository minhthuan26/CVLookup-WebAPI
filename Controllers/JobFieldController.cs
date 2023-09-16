using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.JobFieldService;
using CVLookup_WebAPI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVLookup_WebAPI.Controllers
{
	[Route("api/v1/[controller]/")]
	[ApiController]
	public class JobFieldController : ControllerBase
	{
		private readonly IJobFieldService _jobFieldService;
		private readonly ILogger<JobFieldController> _logger;

		public JobFieldController(ILogger<JobFieldController> logger, IJobFieldService jobFieldService)
		{
			_jobFieldService = jobFieldService;
			_logger = logger;
		}
		/// <summary>
		/// Lấy tất cả lĩnh vực công việc
		/// </summary>
		/// <returns></returns>
		[HttpGet("get-all-job-field")]
		public async Task<IActionResult> getAllJobField()
		{
			try
			{
				var result = await _jobFieldService.JobFieldList();
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
		/// Tìm kiếm lĩnh vực bằng id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("get-job-field-by-id")]
		public async Task<IActionResult> getJobFieldById([FromQuery] string id)
		{
			try
			{
				var result = await _jobFieldService.GetJobFieldById(id);
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
		/// Tìm kiếm lĩnh vực bằng tên
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		[HttpGet("get-job-field-by-address")]
		public async Task<IActionResult> getJobFieldByAddress([FromQuery] string name)
		{
			try
			{
				var result = await _jobFieldService.GetJobFieldByName(name);
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
		/// Thêm lĩnh vực công việc mới
		/// </summary>
		/// <param name="jobAddress"></param>
		/// <returns></returns>
		[HttpPost("add-job-field")]
		public async Task<IActionResult> addJobField([FromBody] JobFieldVM jobAddress)
		{
			try
			{
				var result = await _jobFieldService.Add(jobAddress);
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
		/// Xoá lĩnh vực công việc
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete("delete")]
		public async Task<IActionResult> deleteJobField([FromQuery] string id)
		{
			try
			{

				var result = await _jobFieldService.Delete(id);
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
		/// Cập nhật lĩnh vực làm việc
		/// </summary>
		/// <param name="id"></param>
		/// <param name="jobAddressVM"></param>
		/// <returns></returns>
		[HttpPatch("update")]
		public async Task<IActionResult> updateJobField([FromQuery] string id, [FromBody] JobFieldVM jobAddressVM)
		{
			try
			{
				var result = await _jobFieldService.Update(id, jobAddressVM);
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
