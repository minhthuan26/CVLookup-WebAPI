using CVLookup_WebAPI.Middleware;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.JobPositionService;
using CVLookup_WebAPI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVLookup_WebAPI.Controllers
{
    [Route("api/v1/[controller]/")]
    [ApiController]
    [MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
    [AuthorizationAttribute("Admin")]
    public class JobPositionController : ControllerBase
    {
        private readonly IJobPositionService _jobPositionService;
        private readonly ILogger<JobPositionController> _logger;

        public JobPositionController(ILogger<JobPositionController> logger, IJobPositionService jobPositionService)
        {
            _jobPositionService = jobPositionService;
            _logger = logger;
        }
        /// <summary>
        /// Lấy tất cả vị trí công việc
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-job-position")]
        public async Task<IActionResult> GetAllJobPosition()
        {
            var result = await _jobPositionService.JobPositionList();
            return Ok(new ApiResponse
            {
                Code = StatusCodes.Status200OK,
                Success = true,
                Data = result,
                Message = "Hoàn thành"
            });
        }

        /// <summary>
        /// Tìm kiếm vị trí bằng id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-job-position-by-id")]
        public async Task<IActionResult> GetJobPositionById([FromQuery] string id)
        {
            var result = await _jobPositionService.GetJobPositionById(id);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = "Hoàn thành"
            });
        }

        /// <summary>
        /// Tìm kiếm vị trí bằng tên
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("get-job-position-by-name")]
        public async Task<IActionResult> GetJobPositionsByName([FromQuery] string name)
        {
            var result = await _jobPositionService.GetJobPositionsByName(name);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = "Hoàn thành"
            });
        }

        /// <summary>
        /// Thêm vị trí công việc mới
        /// </summary>
        /// <param name="jobPosition"></param>
        /// <returns></returns>
        [HttpPost("add-job-position")]
        public async Task<IActionResult> AddJobPosition([FromBody] JobPositionVM jobPosition)
        {
            var result = await _jobPositionService.Add(jobPosition);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = "Hoàn thành"
            });
        }

        /// <summary>
        /// Xoá vị trí công việc
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteJobPosition([FromQuery] string id)
        {
            var result = await _jobPositionService.Delete(id);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = "Hoàn thành"
            });
        }

        /// <summary>
        /// Cập nhật vị trí làm việc
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jobPositionVM"></param>
        /// <returns></returns>
        [HttpPatch("update")]
        public async Task<IActionResult> UpdateJobPosition([FromQuery] string id, [FromBody] JobPositionVM jobPositionVM)
        {
            var result = await _jobPositionService.Update(id, jobPositionVM);
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
