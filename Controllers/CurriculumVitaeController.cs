using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.CurriculumService;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CVLookup_WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CurriculumVitaeController : ControllerBase
    {

        private readonly ILogger<CurriculumVitaeController> _logger;
        private readonly ICurriculumViateService _curriculumViateService;

        public CurriculumVitaeController(ILogger<CurriculumVitaeController> logger,ICurriculumViateService curriculumViateService)
        {
            _logger = logger;
            _curriculumViateService = curriculumViateService;
        }

        /// <summary>
        /// Tạo CV
        /// </summary>
        /// <param name="curriculumVitaeVM">The CurriculumVitae data</param>
        /// <returns>The created CurriculumVitae</returns>
        [HttpPost("add-curriculum-vitae")]
        public async Task<IActionResult> AddCurriculumVitae([FromBody] CurriculumVitaeVM curriculumVitaeVM)
        {
            try
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
        /// Lấy danh sách CV
        /// </summary>
        /// <returns>A list of CurriculumVitae</returns>
        [HttpGet("get-all-curriculum-vitae")]
        public async Task<IActionResult> GetAllCurriculumVitae()
        {
            try
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
        /// Xoá CV
        /// </summary>
        /// <param name="id">The ID of the CurriculumVitae to delete</param>
        /// <returns>The deleted CurriculumVitae</returns>
        [HttpDelete("delete-curriculum-vitae")]
        public async Task<IActionResult> DeleteCurriculumVitae([FromQuery] string id)
        {
            try
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
        /// Lấy CV dựa vào ID
        /// </summary>
        /// <param name="id">The ID of the CurriculumVitae to retrieve</param>
        /// <returns>The requested CurriculumVitae</returns>
        [HttpGet("get-curriculum-vitae-by-id")]
        public async Task<IActionResult> GetCurriculumVitaeById([FromQuery] string id)
        {
            try
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
        /// Lấy CV theo Id ứng viên
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-curriculum-vitae-by-candidateId")]
        public async Task<IActionResult> GetByCandidateId([FromQuery] string id)
        {
            try
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
        /// Sửa CV
        /// </summary>
        /// <param name="id">The ID of the CurriculumVitae to update</param>
        /// <param name="newCurriculumVitaeVM">The updated CurriculumVitae data</param>
        /// <returns>The updated CurriculumVitae</returns>
        [HttpPatch("update-curriculum-vitae")]
        public async Task<IActionResult> UpdateCurriculumVitae([FromQuery] string id, [FromBody] CurriculumVitaeVM newCurriculumVitaeVM)
        {
            try
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
