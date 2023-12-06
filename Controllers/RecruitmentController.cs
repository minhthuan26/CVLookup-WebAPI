using AutoMapper;
using CVLookup_WebAPI.Middleware;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.RecruitmentService;
using CVLookup_WebAPI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CVLookup_WebAPI.Controllers
{
    [Route("api/v1/[controller]/")]
    [ApiController]
    [AllowAnonymous]
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
            var result = await _recruimentService.RecruitmentList();
            return Ok(new ApiResponse
            {
                Code = StatusCodes.Status200OK,
                Success = true,
                Data = result,
                Message = "Hoàn thành"
            });
        }

        /// <summary>
        /// Lấy tất cả đơn tuyển dụng công việc theo nhà tuyển dụng
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-recruitment-by-employer")]
        [MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
        [AuthorizationAttribute("Admin", "Employer")]
        public async Task<IActionResult> GetAllRecruitmentByEmployer()
        {
            var result = await _recruimentService.GetAllByEmployer();
            return Ok(new ApiResponse
            {
                Code = StatusCodes.Status200OK,
                Success = true,
                Data = result,
                Message = "Hoàn thành"
            });
        }

        [HttpGet("get-recruitment")]
        public async Task<IActionResult> GetRecruitment([FromQuery]Filter filter)
        {
			var result = await _recruimentService.GetRecruitment(filter);
			return Ok(new ApiResponse
			{
				Code = StatusCodes.Status200OK,
				Success = true,
				Data = result,
				Message = "Hoàn thành"
			});
		}

        /// <summary>
        /// Tìm kiếm đơn tuyển dụng bằng id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-recruitment-by-id")]
        public async Task<IActionResult> GetRecruitmentById([FromQuery] string id)
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

        /// <summary>
        /// Tìm kiếm đơn tuyển dụng bằng tên
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("get-recruitment-by-title")]
        public async Task<IActionResult> GetRecruitmentByTitle([FromQuery] string name)
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

        /// <summary>
        /// Thêm đơn tuyển dụng công việc mới
        /// </summary>
        /// <param name="recruiment"></param>
        /// <returns></returns>
        [HttpPost("add-recruitment")]
		[MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
		[Authorization("Employer", "Admin")]
		public async Task<IActionResult> AddRecruitment([FromBody] RecruitmentVM recruiment)
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

        /// <summary>
        /// Xoá đơn tuyển dụng công việc
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
		[MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
		[Authorization("Employer", "Admin")]
		public async Task<IActionResult> DeleteRecruitment([FromQuery] string id)
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

        /// <summary>
        /// Cập nhật đơn tuyển dụng làm việc
        /// </summary>
        /// <param name="id"></param>
        /// <param name="recruimentVM"></param>
        /// <returns></returns>
        [HttpPatch("update")]
		[MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
		[Authorization("Employer", "Admin")]
		public async Task<IActionResult> UpdateRecruitment([FromQuery] string id, [FromBody] RecruitmentVM recruimentVM)
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

    }
}
