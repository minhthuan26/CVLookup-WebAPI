using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.AuthService;
using CVLookup_WebAPI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVLookup_WebAPI.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger,IAuthService authService) 
        {
            _authService = authService;
            _logger = logger;
        }
        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <param name="loginVM"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AccountVM loginVM)
        {
            try
            {
                var result = await _authService.Login(loginVM);
                    return Ok(new ApiResponse
                    {
                        Success = true,
                        Code = StatusCodes.Status200OK,
                        Message = "Đăng nhập thành công.",
                        Data = result
                    });
                
            }
            catch (Exception e)
            {
                return Ok(new ApiResponse
                {
                    Success = false,
                    Code = StatusCodes.Status500InternalServerError,
                    Message = e.Message,
                });
                throw;
            }
        }


        /// <summary>
        /// Đăng ký tài khoản ứng viên
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("register/candidate")]
        public async Task<IActionResult> RegisterCandidate([FromBody] CandidateRegistrationRequest request)
        {
            try
            {
                var result = await _authService.RegisterCandidate(request.candidateVM, request.accountVM);
                return Ok(new ApiResponse
                {
                    Success = true,
                    Code = StatusCodes.Status200OK,
                    Message = "Đăng ký thành công.",
                    Data = result
                });
            }
            catch (Exception e)
            {
                return Ok(new ApiResponse
                {
                    Success = false,
                    Code = StatusCodes.Status400BadRequest,
                    Message = e.Message,
                });
            }
        }


        /// <summary>
        /// Đăng ký tài khoản nhà tuyển dụng
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("register/employer")]
        public async Task<IActionResult> RegisterEmployer([FromBody] EmployerRegistrationRequest request)
        {
            try
            {
                var result = await _authService.RegisterEmployer(request.employerVM, request.accountVM);
                return Ok(new ApiResponse
                {
                    Success = true,
                    Code = StatusCodes.Status200OK,
                    Message = "Đăng ký thành công.",
                    Data = result
                });
            }
            catch (Exception e)
            {
                return Ok(new ApiResponse
                {
                    Success = false,
                    Code = StatusCodes.Status400BadRequest,
                    Message = e.Message,
                });
            }
        }


        /// <summary>
        /// Tạo mới token
        /// </summary>
        /// <param name="tokenVM"></param>
        /// <returns></returns>
        [HttpPost("renew-token")]
       public async Task<IActionResult> RenewToken(TokenVM tokenVM)
        {
            try
            {
                var result = await _authService.RenewToken(tokenVM);
                return Ok(new ApiResponse
                {
                    Success = true,
                    Code = StatusCodes.Status200OK,
                    Message = "Thành công.",
                    Data = result
                });
            }
            catch (Exception e)
            {
                return Ok(new ApiResponse
                {
                    Success = false,
                    Code = StatusCodes.Status400BadRequest,
                    Message = e.Message,
                });
            }
        }
    }
    
}
