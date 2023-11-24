using AutoMapper;
using CVLookup_WebAPI.Middleware;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.CurriculumService;
using CVLookup_WebAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CVLookup_WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CurriculumVitaeController : ControllerBase
    {

        private readonly ILogger<CurriculumVitaeController> _logger;
        private readonly ICurriculumViateService _curriculumViateService;

        public CurriculumVitaeController(ILogger<CurriculumVitaeController> logger, ICurriculumViateService curriculumViateService)
        {
            _logger = logger;
            _curriculumViateService = curriculumViateService;
        }

		/// <summary>
		/// Tải xuống CV
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("download-curriculum-vitae")]
		[MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
		[Authorization("Admin", "Candidate")]
		public async Task<IActionResult> DownloadCurriculumVitae([FromQuery] string id)
        {
            var result = await _curriculumViateService.DownloadCV(id);

            return File(result.Bytes, result.ContentType, result.FilePath);
        }

		/// <summary>
		/// Lấy danh sách CV
		/// </summary>
		/// <returns>A list of CurriculumVitae</returns>
		[HttpGet("get-all-curriculum-vitae")]
		[MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
		[Authorization("Admin","Candidate")]
		public async Task<IActionResult> GetAllCurriculumVitae()
        {
            var result = await _curriculumViateService.CurriculumVitaeList();

            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = "Hoàn thành"
            });
        }

        /// <summary>
        /// Xoá CV
        /// </summary>
        /// <param name="id">The ID of the CurriculumVitae to delete</param>
        /// <returns>The deleted CurriculumVitae</returns>
        [HttpDelete("delete-curriculum-vitae")]
		[MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
		[Authorization("Admin", "Candidate")]
		public async Task<IActionResult> DeleteCurriculumVitae([FromQuery] string id)
        {
            var result = await _curriculumViateService.Delete(id);

            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = "Hoàn thành"
            });
        }

        /// <summary>
        /// Lấy CV dựa vào ID
        /// </summary>
        /// <param name="id">The ID of the CurriculumVitae to retrieve</param>
        /// <returns>The requested CurriculumVitae</returns>
        [HttpGet("get-curriculum-vitae-by-id")]
		[MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
		[Authorization("Admin", "Candidate","Employer")]
		public async Task<IActionResult> GetCurriculumVitaeById([FromQuery] string id)
        {
            var result = await _curriculumViateService.GetCurriculumVitaeById(id);

            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = "Hoàn thành"
            });
        }


        /// <summary>
        /// Lấy CV theo Id ứng viên
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-curriculum-vitae-by-candidateId")]
		[MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
		[Authorization("Admin", "Candidate")]
		public async Task<IActionResult> GetByCandidateId([FromQuery] string id)
        {
            var result = await _curriculumViateService.GetByCandidateId(id);

            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = "Hoàn thành"
            });
        }

		[HttpGet("get-current-user-cv-uploaded")]
		[MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
		[Authorization("Admin", "Candidate")]
		public async Task<IActionResult> GetCurrentUserCVUploaded()
		{
			var result = await _curriculumViateService.GetCurrentUserCVUploaded();

			return Ok(new ApiResponse
			{
				Success = true,
				Code = StatusCodes.Status200OK,
				Data = result,
				Message = "Hoàn thành"
			});
		}

		/// <summary>
		/// Sửa CV
		/// </summary>
		/// <param name="id">The ID of the CurriculumVitae to update</param>
		/// <param name="newCurriculumVitaeVM">The updated CurriculumVitae data</param>
		/// <returns>The updated CurriculumVitae</returns>
		[HttpPatch("update-curriculum-vitae")]
        public async Task<IActionResult> UpdateCurriculumVitae([FromQuery] string id, [FromBody] CurriculumVitaeVM newCurriculumVitaeVM)
        {
            var result = await _curriculumViateService.Update(id, newCurriculumVitaeVM);

            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = "Hoàn thành"
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="curriculumVitaeVM"></param>
        /// <returns></returns>
        [HttpPost("upload-curriculum-vitae")]
        [MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
        [Authorization("Admin", "Candidate")]
        public async Task<IActionResult> UploadCurriculumVitae([FromForm] CurriculumVitaeVM curriculumVitaeVM)
        {
            var result = await _curriculumViateService.Add(curriculumVitaeVM);

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
