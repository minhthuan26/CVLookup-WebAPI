using AutoMapper;
using CVLookup_WebAPI.Middleware;
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
    [Route("api/v1/[controller]")]
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
		[MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
		[AuthorizationAttribute("Admin", "Employer")]
		public async Task<IActionResult> GetRecruitmentCVBy_RecruitmentId([FromQuery] string id)
        {
            var result = await _recruitmentCVService.GetRecruitmentCVBy_RecruitmentId(id);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Hoàn thành",
                Data = result
            });
        }

        /// <summary>
        /// Lấy thông tin RecruitmentCV theo CurriculumVitaeId
        /// </summary>
        /// <param name="id">ID của CurriculumVitae</param>
        /// <returns>Thông tin RecruitmentCV</returns>
        [HttpGet("get-by-cv-id")]
		[MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
		[AuthorizationAttribute("Admin", "Candidate")]
		public async Task<IActionResult> GetRecruitmentCVBy_CVId([FromQuery] string id)
        {
            var recruitmentCV = await _recruitmentCVService.GetRecruitmentCVBy_CVId(id);
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
        /// </summary>\
        /// <param name="id">ID của CurriculumVitae</param>
        /// <returns>Thông tin RecruitmentCV</returns>
        [HttpGet("get-by-isPass")]
        [MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
        [AuthorizationAttribute("Admin", "Employer")]
        public async Task<IActionResult> GetCVBy_IsPass([FromQuery] string id)
        {
            var recruitmentCV = await _recruitmentCVService.GetRecruitmentCVByIsPass(id);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Hoàn thành",
                Data = recruitmentCV
            });
        }
        
        /// <param name="cvId"></param>
        /// <param name="recruitmentId"></param>
        /// <returns></returns>
		[HttpGet("get-by-cv-and-recruitment-id")]
		[MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
		[AuthorizationAttribute("Admin", "Employer")]
		public async Task<IActionResult> GetRecruitmentCVBy_CvId_And_RecruitmentId([FromQuery] string cvId, [FromQuery] string recruitmentId)
		{
			var recruitmentCV = await _recruitmentCVService.GetRecruitmentBy_CvId_And_RecruitmentId(cvId, recruitmentId);
			return Ok(new ApiResponse
			{
				Success = true,
				Code = StatusCodes.Status200OK,
				Message = "Hoàn thành",
				Data = recruitmentCV
			});
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cvId"></param>
        /// <param name="recruitmentId"></param>
        /// <returns></returns>
		[HttpGet("get-by-user-and-recruitment-id")]
        [MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
        [AuthorizationAttribute("Admin", "Candidate")]
        public async Task<IActionResult> GetRecruitmentCVBy_UserId_And_RecruitmentId([FromQuery] string userId, [FromQuery] string recruitmentId)
        {
            var recruitmentCV = await _recruitmentCVService.GetRecruitmentBy_UserId_And_RecruitmentId(userId, recruitmentId);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Hoàn thành",
                Data = recruitmentCV
            });
        }

        /// <summary>
        /// Nộp CV ứng tuyển
        /// </summary>
        /// <param name="recruitmentCVVM"></param>
        /// <returns></returns>
        [HttpPost("apply-to-recruitment")]
		[MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
		[AuthorizationAttribute("Admin", "Candidate")]
		public async Task<IActionResult> ApplyToRecruitment([FromBody] RecruitmentCVVM recruitmentCVVM)
        {
            var newRecruitmentCV = await _recruitmentCVService.ApplyToRecruitment(recruitmentCVVM);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Hoàn thành",
                Data = newRecruitmentCV
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cvId"></param>
        /// <param name="recruitmentId"></param>
        /// <returns></returns>
        [HttpPatch("update-isView")]
        [MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
        [AuthorizationAttribute("Admin", "Employer")]
        public async Task<IActionResult> UpdateIsView([FromQuery] string cvId, [FromQuery] string recruitmentId)
        {
            var newRecruitmentCV = await _recruitmentCVService.UpdateIsView(cvId, recruitmentId);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Hoàn thành",
                Data = newRecruitmentCV
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cvId"></param>
        /// <param name="recruitmentId"></param>
        /// <returns></returns>
        [HttpPatch("toggle-isPass")]
        [MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
        [AuthorizationAttribute("Admin", "Employer")]
        public async Task<IActionResult> ToggleIsPass([FromQuery] string cvId, [FromQuery] string recruitmentId)
        {
            var newRecruitmentCV = await _recruitmentCVService.ToggleIsPass(cvId, recruitmentId);
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
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-cv-applied")]
        [MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
        [AuthorizationAttribute("Admin", "Employer")]
        public async Task<IActionResult> GetAllCVApplied([FromQuery] string recruitmentId)
		{
			var result = await _recruitmentCVService.GetAllCVApplied(recruitmentId);
			return Ok(new ApiResponse
			{
				Success = true,
				Code = StatusCodes.Status200OK,
				Message = "Hoàn thành",
				Data = result
			});
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recruitmentId"></param>
        /// <param name="userId"></param>
        /// <param name="cvId"></param>
        /// <returns></returns>
		[HttpPatch("update-applied-cv")]
		[MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
		[AuthorizationAttribute("Admin", "Candidate")]
		public async Task<IActionResult> UpdateAppliedCV([FromQuery] string recruitmentId, [FromQuery] string userId, [FromQuery] string cvId)
		{
			var result = await _recruitmentCVService.ReApplyCV(recruitmentId, userId, cvId);
			return Ok(new ApiResponse
			{
				Success = true,
				Code = StatusCodes.Status200OK,
				Message = "Hoàn thành",
				Data = result
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
