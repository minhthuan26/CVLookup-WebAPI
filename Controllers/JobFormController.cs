using CVLookup_WebAPI.Middleware;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.JobFormService;
using CVLookup_WebAPI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVLookup_WebAPI.Controllers
{
    [Route("api/v1/[controller]/")]
    [ApiController]
    [MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
    [AuthorizationAttribute("Admin")]
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
        public async Task<IActionResult> GetAllJobForm()
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

        /// <summary>
        /// Tìm kiếm hình thức bằng id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-job-form-by-id")]
        public async Task<IActionResult> GetJobFormById([FromQuery] string id)
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

        /// <summary>
        /// Tìm kiếm hình thức bằng tên
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("get-job-form-by-name")]
        public async Task<IActionResult> GetJobFormsByName([FromQuery] string name)
        {
            var result = await _jobFormService.GetJobFormsByName(name);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = "Hoàn thành"
            });
        }

        /// <summary>
        /// Thêm hình thức công việc mới
        /// </summary>
        /// <param name="jobForm"></param>
        /// <returns></returns>
        [HttpPost("add-job-form")]
        public async Task<IActionResult> AddJobForm([FromBody] JobFormVM jobForm)
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

        /// <summary>
        /// Xoá hình thức công việc
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteJobForm([FromQuery] string id)
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

        /// <summary>
        /// Cập nhật hình thức làm việc
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jobFormVM"></param>
        /// <returns></returns>
        [HttpPatch("update")]
        public async Task<IActionResult> UpdateJobForm([FromQuery] string id, [FromBody] JobFormVM jobFormVM)
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

    }
}
