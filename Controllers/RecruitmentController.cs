using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.RecruitmentService;
using CVLookup_WebAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CVLookup_WebAPI.Controllers
{
	[Route("api/v1/[controller]/")]
	[ApiController]
	public class RecruitmentController : ControllerBase
	{
		private readonly IRecruitmentService _recruimentService;
		private readonly ILogger<RecruitmentController> _logger;

		public RecruitmentController(ILogger<RecruitmentController> logger, IRecruitmentService recruimentService)
		{
			_recruimentService = recruimentService;
			_logger = logger;
		}
		/// <summary>
		/// Lấy tất cả đơn tuyển dụng công việc
		/// </summary>
		/// <returns></returns>
		[HttpGet("get-all-recruitment")]
		public async Task<IActionResult> GetAllRecruitment()
		{
			try
			{
				var result = await _recruimentService.RecruitmentList();
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
		/// Tìm kiếm đơn tuyển dụng bằng id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("get-recruitment-by-id")]
		public async Task<IActionResult> GetRecruitmentById([FromQuery] string id)
		{
			try
			{
				var result = await _recruimentService.GetRecruitmentById(id);
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
		/// Tìm kiếm đơn tuyển dụng bằng tên
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		[HttpGet("get-recruitment-by-title")]
		public async Task<IActionResult> GetRecruitmentByTitle([FromQuery] string name)
		{
			try
			{
				var result = await _recruimentService.GetRecruitmentsByTitle(name);
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
		/// Thêm đơn tuyển dụng công việc mới
		/// </summary>
		/// <param name="recruiment"></param>
		/// <returns></returns>
		[HttpPost("add-recruitment")]
		public async Task<IActionResult> AddRecruitment([FromBody] RecruitmentVM recruiment)
		{
			try
			{
				var result = await _recruimentService.Add(recruiment);
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
		/// Xoá đơn tuyển dụng công việc
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete("delete")]
		public async Task<IActionResult> DeleteRecruitment([FromQuery] string id)
		{
			try
			{

				var result = await _recruimentService.Delete(id);
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
		/// Cập nhật đơn tuyển dụng làm việc
		/// </summary>
		/// <param name="id"></param>
		/// <param name="recruimentVM"></param>
		/// <returns></returns>
		[HttpPatch("update")]
		public async Task<IActionResult> UpdateRecruitment([FromQuery] string id, [FromBody] RecruitmentVM recruimentVM)
		{
			try
			{
				var result = await _recruimentService.Update(id, recruimentVM);
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
