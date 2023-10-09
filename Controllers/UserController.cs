using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.UserService;
using CVLookup_WebAPI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVLookup_WebAPI.Controllers
{
    [Route("api/v1/[controller]/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _userService = userService;
            _logger = logger;
        }

        /// <summary>
        /// Thêm ứng viên mới
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        [HttpPost("add-candidate")]
        public async Task<IActionResult> AddCandidate([FromBody] CandidateVM candidate)
        {
            var result = await _userService.AddCandidate(candidate);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = "Hoàn thành"
            });
        }

        /// <summary>
        /// Thêm nhà tuyển dụng mới
        /// </summary>
        /// <param name="employer"></param>
        /// <returns></returns>
        [HttpPost("add-employer")]
        public async Task<IActionResult> AddEmployer([FromBody] EmployerVM employer)
        {
            var result = await _userService.AddEmployer(employer);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Hoàn thành",
                Code = StatusCodes.Status200OK,
                Data = result
            });
        }

        /// <summary>
        /// Lấy danh sách ứng viên theo họ tên
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("get-candidate-by-name")]
        public async Task<IActionResult> GetCandidatesByName([FromQuery] string? name)
        {
            var result = await _userService.GetCandidatesByName(name);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Hoàn thành",
                Code = StatusCodes.Status200OK,
                Data = result
            });
        }

        /// <summary>
        /// Lấy danh sách nhà tuyển dụng theo tên
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("get-employer-by-name")]
        public async Task<IActionResult> GetEmployersByName([FromQuery] string? name)
        {
            var result = await _userService.GetEmployersByName(name);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Hoàn thành",
                Code = StatusCodes.Status200OK,
                Data = result
            });
        }

        /// <summary>
        /// Lấy danh sách người dùng
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-user")]
        public async Task<IActionResult> GetUserList()
        {
            var result = await _userService.UserList();
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Hoàn thành",
                Code = StatusCodes.Status200OK,
                Data = result
            });
        }

        /// <summary>
        /// Xoá người dùng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete-user")]
        public async Task<IActionResult> delete([FromQuery] string id)
        {
            var result = await _userService.Delete(id);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Hoàn thành",
                Code = StatusCodes.Status200OK,
                Data = result
            });
        }

        /// <summary>
        /// Lấy người dùng bằng id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-user-by-id")]
        public async Task<IActionResult> GetUserById([FromQuery] string id)
        {
            var result = await _userService.GetUserById(id);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Hoàn thành",
                Code = StatusCodes.Status200OK,
                Data = result
            });
        }

        /// <summary>
        /// Lấy người dùng bằng email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("get-user-by-email")]
        public async Task<IActionResult> GetUserByEmail([FromQuery] string? email)
        {
            var result = await _userService.GetUserByEmail(email);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Hoàn thành",
                Code = StatusCodes.Status200OK,
                Data = result
            });
        }

        /// <summary>
        /// Sửa thông tin ứng viên
        /// </summary>
        /// <param name="id"></param>
        /// <param name="candidate"></param>
        /// <returns></returns>
        [HttpPatch("update-candidate")]
        public async Task<IActionResult> UpdateCandidate([FromQuery] string id, [FromBody] CandidateVM candidate)
        {
            var result = await _userService.UpdateCandidate(id, candidate);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Hoàn thành",
                Code = StatusCodes.Status200OK,
                Data = result
            });
        }

        /// <summary>
        /// Sửa thông tin nhà tuyển dụng
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employer"></param>
        /// <returns></returns>
        [HttpPatch("update-employer")]
        public async Task<IActionResult> UpdateEmployer([FromQuery] string id, [FromBody] EmployerVM employer)
        {
            var result = await _userService.UpdateEmployer(id, employer);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Hoàn thành",
                Code = StatusCodes.Status200OK,
                Data = result
            });
        }
    }
}
