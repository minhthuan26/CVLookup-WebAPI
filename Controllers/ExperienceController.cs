using CVLookup_WebAPI.Middleware;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.ExperienceService;
using CVLookup_WebAPI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVLookup_WebAPI.Controllers
{
    [Route("api/v1/[controller]/")]
    [ApiController]
    [MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
    [AuthorizationAttribute("Admin")]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService _experienceService;
        private readonly ILogger<ExperienceController> _logger;

        public ExperienceController(ILogger<ExperienceController> logger, IExperienceService experienceService)
        {
            _experienceService = experienceService;
            _logger = logger;
        }
        /// <summary>
        /// Lấy tất cả kinh nghiệm công việc
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-experience")]
        public async Task<IActionResult> GetAllExperience()
        {
            var result = await _experienceService.ExperienceList();
            return Ok(new ApiResponse
            {
                Code = StatusCodes.Status200OK,
                Success = true,
                Data = result,
                Message = "Hoàn thành"
            });
        }

        /// <summary>
        /// Tìm kiếm kinh nghiệm bằng id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-experience-by-id")]
        public async Task<IActionResult> GetExperienceById([FromQuery] string id)
        {
            var result = await _experienceService.GetExperienceById(id);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = "Hoàn thành"
            });
        }

        /// <summary>
        /// Tìm kiếm kinh nghiệm bằng tên
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpGet("get-experience-by-value")]
        public async Task<IActionResult> GetExperienceByValue([FromQuery] string value)
        {
            var result = await _experienceService.GetExperiencesByValue(value);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = "Hoàn thành"
            });
        }

        /// <summary>
        /// Thêm kinh nghiệm công việc mới
        /// </summary>
        /// <param name="experience"></param>
        /// <returns></returns>
        [HttpPost("add-experience")]
        public async Task<IActionResult> AddExperience([FromBody] ExperienceVM experience)
        {
            var result = await _experienceService.Add(experience);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = "Hoàn thành"
            });
        }

        /// <summary>
        /// Xoá kinh nghiệm công việc
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteExperience([FromQuery] string id)
        {
            var result = await _experienceService.Delete(id);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = "Hoàn thành"
            });
        }

        /// <summary>
        /// Cập nhật kinh nghiệm làm việc
        /// </summary>
        /// <param name="id"></param>
        /// <param name="experienceVM"></param>
        /// <returns></returns>
        [HttpPatch("update")]
        public async Task<IActionResult> UpdateExperience([FromQuery] string id, [FromBody] ExperienceVM experienceVM)
        {
            var result = await _experienceService.Update(id, experienceVM);
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
