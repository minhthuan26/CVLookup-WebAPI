﻿using AutoMapper;
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
		public async Task<IActionResult> GetRecruitmentCVByRecruitmentId([FromQuery] string id)
        {
            var result = await _recruitmentCVService.GetRecruitmentCVByRecruitmentId(id);
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
        [HttpGet("get-by-curriculum-vitae-id")]
		[MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
		[AuthorizationAttribute("Admin", "Candidate")]
		public async Task<IActionResult> GetRecruitmentCVByCurriculumVitaeId([FromQuery] string id)
        {
            var recruitmentCV = await _recruitmentCVService.GetRecruitmentCVByCurriculumVitaeId(id);
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
        /// CẬp nhật trạng thái xem CV
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPatch("update-isView")]
        [MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
        [AuthorizationAttribute("Admin", "Employer")]
        public async Task<IActionResult> UpdateIsView([FromQuery] string id)
        {
            var newRecruitmentCV = await _recruitmentCVService.UpdateIsView(id);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Hoàn thành",
                Data = newRecruitmentCV
            });
        }

        /// <summary>
        /// Api dùng để chuyển đỗi trạng thái isPass
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPatch("toggle-isPass")]
        [MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
        [AuthorizationAttribute("Admin", "Employer")]
        public async Task<IActionResult> ToggleIsPass([FromQuery] string id)
        {
            var newRecruitmentCV = await _recruitmentCVService.ToggleIsPass(id);
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
