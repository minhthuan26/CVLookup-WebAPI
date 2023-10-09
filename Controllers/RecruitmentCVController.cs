using AutoMapper;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.RecruitmentCVService;
using CVLookup_WebAPI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CVLookup_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitmentCVController : ControllerBase
    {
        private readonly IRecruitmentCVService _recruitmentCVService;
        private readonly ILogger<RecruitmentCVController> _logger;

        public RecruitmentCVController(
            ILogger<RecruitmentCVController> logger,
            IRecruitmentCVService recruitmentCVService
           )
        {
            _recruitmentCVService = recruitmentCVService;
            _logger = logger;
        }

        /// <summary>
        /// Lấy thông tin RecruitmentCV theo RecruitmentId
        /// </summary>
        /// <param name="id">ID của Recruitment</param>
        /// <returns>Thông tin RecruitmentCV</returns>
        [HttpGet("get-by-recruitment-id")]
        public async Task<IActionResult> GetRecruitmentCVByRecruitmentId([FromQuery] string id)
        {
            var recruitmentCV = await _recruitmentCVService.GetAccountByRecruitmentId(id);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Hoàn thành",
                Data = recruitmentCV
            });
        }

        /// <summary>
        /// Lấy thông tin RecruitmentCV theo CurriculumVitaeId
        /// </summary>
        /// <param name="id">ID của CurriculumVitae</param>
        /// <returns>Thông tin RecruitmentCV</returns>
        [HttpGet("get-by-curriculum-vitae-id")]
        public async Task<IActionResult> GetRecruitmentCVByCurriculumVitaeId([FromQuery] string id)
        {
            var recruitmentCV = await _recruitmentCVService.GetAccountByCurriculumVitaeId(id);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Hoàn thành",
                Data = recruitmentCV
            });
        }

        /// <summary>
        /// Thêm mới RecruitmentCV
        /// </summary>
        /// <param name="recruitmentCVVM">Thông tin RecruitmentCV cần thêm</param>
        /// <returns>Thông tin RecruitmentCV đã thêm</returns>
        [HttpPost("create-recruitment-cv")]
        public async Task<IActionResult> AddRecruitmentCV([FromBody] RecruitmentCVVM recruitmentCVVM)
        {
            var newRecruitmentCV = await _recruitmentCVService.Add(recruitmentCVVM);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Hoàn thành",
                Data = newRecruitmentCV
            });
        }

        /// <summary>
        /// Xóa RecruitmentCV
        /// </summary>
        /// <param name="recruitmentId">ID của Recruitment</param>
        /// <param name="curriculumVitaeId">ID của CurriculumVitae</param>
        /// <returns>Thông tin RecruitmentCV đã xóa</returns>
        [HttpDelete("delete-recruitment-cv")]
        public async Task<IActionResult> DeleteRecruitmentCV([FromQuery] string recruitmentId, [FromQuery] string curriculumVitaeId)
        {
            var deletedRecruitmentCV = await _recruitmentCVService.Delete(recruitmentId, curriculumVitaeId);
            return Ok(new ApiResponse 
            { 
                Success = true, 
                Code = StatusCodes.Status200OK, 
                Message = "Hoàn thành", 
                Data = deletedRecruitmentCV 
            });
        }
    }
}
