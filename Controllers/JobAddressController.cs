using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.JobAddressService;
using CVLookup_WebAPI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVLookup_WebAPI.Controllers
{
    [Route("api/v1/[controller]/")]
    [ApiController]
    public class JobAddressController : ControllerBase
    {
        private readonly IJobAddressService _jobAddressService;
        private readonly ILogger<JobAddressController> _logger;

        public JobAddressController(ILogger<JobAddressController> logger, IJobAddressService jobAddressService)
        {
            _jobAddressService = jobAddressService;
            _logger = logger;
        }
        /// <summary>
        /// Lấy tất cả địa điểm công việc
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-job-address")]
        public async Task<IActionResult> GetAllJobAddress()
        {
            var result = await _jobAddressService.JobAddressList();
            return Ok(new ApiResponse
            {
                Code = StatusCodes.Status200OK,
                Success = true,
                Data = result,
                Message = "Hoàn thành"
            });
        }

        /// <summary>
        /// Tìm kiếm địa điểm bằng id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-job-address-by-id")]
        public async Task<IActionResult> GetJobAddressById([FromQuery] string id)
        {
            var result = await _jobAddressService.GetJobAddressById(id);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = "Hoàn thành"
            });
        }

        /// <summary>
        /// Tìm kiếm địa điểm bằng tên
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpGet("get-job-address-by-name")]
        public async Task<IActionResult> GetJobAddressesByName([FromQuery] string address)
        {
            var result = await _jobAddressService.GetJobAddressesByName(address);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = "Hoàn thành"
            });
        }

        /// <summary>
        /// Thêm địa điểm công việc mới
        /// </summary>
        /// <param name="jobAddress"></param>
        /// <returns></returns>
        [HttpPost("add-job-address")]
        public async Task<IActionResult> AddJobAddress([FromBody] JobAddressVM jobAddress)
        {
            var result = await _jobAddressService.Add(jobAddress);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = "Hoàn thành"
            });
        }

        /// <summary>
        /// Xoá địa điểm công việc
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteJobAddress([FromQuery] string id)
        {
            var result = await _jobAddressService.Delete(id);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = "Hoàn thành"
            });
        }

        /// <summary>
        /// Cập nhật địa điểm làm việc
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jobAddressVM"></param>
        /// <returns></returns>
        [HttpPatch("update")]
        public async Task<IActionResult> UpdateJobAddress([FromQuery] string id, [FromBody] JobAddressVM jobAddressVM)
        {
            var result = await _jobAddressService.Update(id, jobAddressVM);
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
