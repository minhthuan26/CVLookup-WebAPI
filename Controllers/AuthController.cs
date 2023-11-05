using CVLookup_WebAPI.Middleware;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.AuthService;
using CVLookup_WebAPI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;

namespace CVLookup_WebAPI.Controllers
{
    [Route("api/v1/[controller]/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _authService = authService;
            _logger = logger;
        }
        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <param name="accountVM"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AccountVM accountVM)
        {
            var result = await _authService.Login(accountVM);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Đăng nhập thành công.",
                Data = result
            });
        }


        /// <summary>
        /// Đăng ký tài khoản ứng viên
        /// </summary>
        /// <param name="candidateRegister"></param>
        /// <returns></returns>
        [HttpPost("register-candidate")]
        public async Task<IActionResult> RegisterCandidate([FromBody] CandidateRegisterVM candidateRegister)
        {
            var result = await _authService.RegisterCandidate(candidateRegister.Candidate, candidateRegister.Account);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Đăng ký thành công.",
                Data = result
            });
        }


        /// <summary>
        /// Đăng ký tài khoản nhà tuyển dụng
        /// </summary>
        /// <param name="employerRegister"></param>
        /// <returns></returns>
        [HttpPost("register-employer")]
        public async Task<IActionResult> RegisterEmployer([FromBody] EmployerRegisterVM employerRegister)
        {
            var result = await _authService.RegisterEmployer(employerRegister.Employer, employerRegister.Account);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Đăng ký thành công.",
                Data = result
            });
        }


        /// <summary>
        /// Tạo mới token
        /// </summary>
        /// <returns></returns>
        [HttpPost("renew-token")]
		public async Task<IActionResult> RenewToken()
        {
            var result = await _authService.RenewToken();
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Thành công.",
                Data = result
            });
        }


        /// <summary>
        /// Đăng xuất
        /// </summary>
        /// <returns></returns>
        [HttpPost("logout")]
        [HttpGet("logout")]
        [MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
        [Authorization("Admin", "Employer", "Candidate")]
        public async Task<IActionResult> Logout()
        {
            var result = await _authService.Logout();
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Thành công.",
                Data = result
            });
        }

        [HttpGet("active-account")]
        public async Task<IActionResult> ActiveAccount([FromQuery] string? token)
        {
            var result = await _authService.ActiveAccount(token);
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
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost("restore-refresh-token")]
        public async Task<IActionResult> RestoreRefreshToken([FromQuery]string userId)
        {
			await _authService.RestoreRefreshToken(userId);
			return Ok();
		}
    }
}
