using CVLookup_WebAPI.Middleware;
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
        public async Task<IActionResult> GetAllJobField()
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

        /// <summary>
        /// Tìm kiếm lĩnh vực bằng id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-job-field-by-id")]
        public async Task<IActionResult> GetJobFieldById([FromQuery] string id)
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

        /// <summary>
        /// Tìm kiếm lĩnh vực bằng tên
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("get-job-field-by-address")]
        public async Task<IActionResult> GetJobFieldsByAddress([FromQuery] string name)
        {
            var result = await _jobFieldService.GetJobFieldsByName(name);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = "Hoàn thành"
            });
        }

        /// <summary>
        /// Thêm lĩnh vực công việc mới
        /// </summary>
        /// <param name="jobAddress"></param>
        /// <returns></returns>
        [HttpPost("add-job-field")]
		[MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
		[AuthorizationAttribute("Admin")]
		public async Task<IActionResult> AddJobField([FromBody] JobFieldVM jobAddress)
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

        /// <summary>
        /// Xoá lĩnh vực công việc
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
		[MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
		[AuthorizationAttribute("Admin")]
		public async Task<IActionResult> DeleteJobField([FromQuery] string id)
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

        /// <summary>
        /// Cập nhật lĩnh vực làm việc
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jobFieldVM"></param>
        /// <returns></returns>
        [HttpPatch("update")]
		[MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
		[AuthorizationAttribute("Admin")]
		public async Task<IActionResult> UpdateJobField([FromQuery] string id, [FromBody] JobFieldVM jobFieldVM)
        {
            var result = await _jobFieldService.Update(id, jobFieldVM);
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
