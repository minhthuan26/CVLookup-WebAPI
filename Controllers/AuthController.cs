﻿using CVLookup_WebAPI.Services.AuthService;
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

        public AuthController(IAuthService authService) 
        {
            _authService = authService;
        }
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="loginVM"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginVM loginVM)
        {
            try
            {
                var result = _authService.Login(loginVM.Email, loginVM.Password);
                if (result == null)
                {
                    return Ok(new ApiResponse
                    {
                        Success = false,
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Sai Email hoặc mật khẩu.",
                    });
                }
                else
                {
                    return Ok(new ApiResponse
                    {
                        Success = true,
                        Code = StatusCodes.Status200OK,
                        Message = "Đăng nhập thành công.",
                        Data = result
                    });
                }
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
    }
    public class LoginVM
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}