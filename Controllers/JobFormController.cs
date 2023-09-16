using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.JobFormService;
using CVLookup_WebAPI.Services.JobFormService;
using CVLookup_WebAPI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVLookup_WebAPI.Controllers
{
	[Route("api/v1/[controller]/")]
	[ApiController]
	public class JobFormController : ControllerBase
	{
		private readonly IJobFormService _jobFormService;
		private readonly ILogger<JobFormController> _logger;

		public JobFormController(ILogger<JobFormController> logger, IJobFormService jobFormService)
		{
			_jobFormService = jobFormService;
			_logger = logger;
		}
		/// <summary>
		/// Lấy tất cả hình thức công việc
		/// </summary>
		/// <returns></returns>
		[HttpGet("get-all-job-form")]
		public async Task<IActionResult> getAllJobForm()
		{
			try
			{
				var result = await _jobFormService.JobFormList();
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
		/// Tìm kiếm hình thức bằng id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("get-job-form-by-id")]
		public async Task<IActionResult> getJobFormById([FromQuery] string id)
		{
			try
			{
				var result = await _jobFormService.GetJobFormById(id);
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
		/// Tìm kiếm hình thức bằng tên
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		[HttpGet("get-job-form-by-name")]
		public async Task<IActionResult> getJobFormByName([FromQuery] string name)
		{
			try
			{
				var result = await _jobFormService.GetJobFormByName(name);
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
		/// Thêm hình thức công việc mới
		/// </summary>
		/// <param name="jobForm"></param>
		/// <returns></returns>
		[HttpPost("add-job-form")]
		public async Task<IActionResult> addJobForm([FromBody] JobFormVM jobForm)
		{
			try
			{
				var result = await _jobFormService.Add(jobForm);
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
		/// Xoá hình thức công việc
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete("delete")]
		public async Task<IActionResult> deleteJobForm([FromQuery] string id)
		{
			try
			{

				var result = await _jobFormService.Delete(id);
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
		/// Cập nhật hình thức làm việc
		/// </summary>
		/// <param name="id"></param>
		/// <param name="jobFormVM"></param>
		/// <returns></returns>
		[HttpPatch("update")]
		public async Task<IActionResult> updateJobForm([FromQuery] string id, [FromBody] JobFormVM jobFormVM)
		{
			try
			{
				var result = await _jobFormService.Update(id, jobFormVM);
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
