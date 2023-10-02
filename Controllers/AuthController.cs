﻿using CVLookup_WebAPI.Models.ViewModel;
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
			catch (ExceptionReturn e)
			{
				return Ok(new ApiResponse
				{
					Success = false,
					Code = e.Code,
					Message = e.Message,
				});
			}
		}


		/// <summary>
		/// Đăng ký tài khoản ứng viên
		/// </summary>
		/// <param name="candidateRegisterVM"></param>
		/// <returns></returns>
		[HttpPost("register-candidate")]
		public async Task<IActionResult> RegisterCandidate([FromBody] CandidateRegisterVM candidateRegisterVM)
		{
			try
			{
				var result = await _authService.RegisterCandidate(candidateRegisterVM.CandidateVM, candidateRegisterVM.AccountVM);
				return Ok(new ApiResponse
				{
					Success = true,
					Code = StatusCodes.Status200OK,
					Message = "Đăng ký thành công.",
					Data = result
				});
			}
			catch (ExceptionReturn e)
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
		/// <param name="employerRegisterVM"></param>
		/// <returns></returns>
		[HttpPost("register-employer")]
		public async Task<IActionResult> RegisterEmployer([FromBody] EmployerRegisterVM employerRegisterVM)
		{
			try
			{
				var result = await _authService.RegisterEmployer(employerRegisterVM.EmployerVM, employerRegisterVM.AccountVM);
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
		/// <returns></returns>
		[HttpPost("renew-token")]
		public async Task<IActionResult> RenewToken()
		{
			try
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
			catch (ExceptionReturn e)
			{
				return Ok(new ApiResponse
				{
					Success = false,
					Code = e.Code,
					Message = e.Message,
				});
			}
		}


		/// <summary>
		/// Đăng xuất
		/// </summary>
		/// <returns></returns>
		[HttpPost("logout")]
		[HttpGet("logout")]
		public async Task<IActionResult> Logout()
		{
			try
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
			catch (ExceptionReturn e)
			{
				return Ok(new ApiResponse
				{
					Success = false,
					Code = StatusCodes.Status400BadRequest,
					Message = e.Message,
				});
			}
		}

		[HttpGet("active-account")]
		public async Task<IActionResult> ActiveAccount([FromQuery] string? token)
		{
			try
			{
				var result = await _authService.ActiveAccount(token);
				return Ok(new ApiResponse
				{
					Success = true,
					Code = StatusCodes.Status200OK,
					Message = "Hoàn thành",
					Data = result
				});
			} catch (ExceptionReturn e)
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
