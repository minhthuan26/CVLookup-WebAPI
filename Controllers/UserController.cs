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
		/// <param name="candidateVM"></param>
		/// <returns></returns>
		[HttpPost("add-candidate")]
		public async Task<IActionResult> AddCandidate([FromBody] CandidateVM candidateVM)
		{
			try
			{
				var result = await _userService.AddCandidate(candidateVM);
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
		/// Thêm nhà tuyển dụng mới
		/// </summary>
		/// <param name="employerVM"></param>
		/// <returns></returns>
		[HttpPost("add-employer")]
		public async Task<IActionResult> AddEmployer([FromBody] EmployerVM employerVM)
		{
			try
			{
				var result = await _userService.AddEmployer(employerVM);
				return Ok(new ApiResponse
				{
					Success = true,
					Message = "Hoàn thành",
					Code = StatusCodes.Status200OK,
					Data = result
				});
			}
			catch (ExceptionReturn e)
			{
				return Ok(new ApiResponse
				{
					Code = e.Code,
					Message = e.Message,
					Success = false
				});
			}
		}

		/// <summary>
		/// Lấy danh sách ứng viên theo họ tên
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		[HttpGet("get-candidate-by-name")]
		public async Task<IActionResult> GetCandidatesByName([FromQuery] string? name)
		{
			try
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
			catch (ExceptionReturn e)
			{
				return Ok(new ApiResponse
				{
					Code = e.Code,
					Message = e.Message,
					Success = false
				});
			}
		}

		/// <summary>
		/// Lấy danh sách nhà tuyển dụng theo tên
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		[HttpGet("get-employer-by-name")]
		public async Task<IActionResult> GetEmployersByName([FromQuery] string? name)
		{
			try
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
			catch (ExceptionReturn e)
			{
				return Ok(new ApiResponse
				{
					Code = e.Code,
					Message = e.Message,
					Success = false
				});
			}
		}

		/// <summary>
		/// Lấy danh sách người dùng
		/// </summary>
		/// <returns></returns>
		[HttpGet("get-all-user")]
		public async Task<IActionResult> GetUserList()
		{
			try
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
			catch (ExceptionReturn e)
			{
				return Ok(new ApiResponse
				{
					Code = e.Code,
					Message = e.Message,
					Success = false
				});
			}
		}

		/// <summary>
		/// Xoá người dùng
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete("delete-user")]
		public async Task<IActionResult> delete([FromQuery] string id)
		{
			try
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
			catch (ExceptionReturn e)
			{
				return Ok(new ApiResponse
				{
					Code = e.Code,
					Message = e.Message,
					Success = false
				});
			}
		}

		/// <summary>
		/// Lấy người dùng bằng id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("get-user-by-id")]
		public async Task<IActionResult> GetUserById([FromQuery] string id)
		{
			try
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
			catch (ExceptionReturn e)
			{
				return Ok(new ApiResponse
				{
					Code = e.Code,
					Message = e.Message,
					Success = false
				});
			}
		}

		/// <summary>
		/// Lấy người dùng bằng email
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		[HttpGet("get-user-by-email")]
		public async Task<IActionResult> GetUserByEmail([FromQuery] string? email)
		{
			try
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
			catch (ExceptionReturn e)
			{
				return Ok(new ApiResponse
				{
					Code = e.Code,
					Message = e.Message,
					Success = false
				});
			}
		}

		/// <summary>
		/// Sửa thông tin ứng viên
		/// </summary>
		/// <param name="id"></param>
		/// <param name="candidateVM"></param>
		/// <returns></returns>
		[HttpPut("update-candidate")]
		public async Task<IActionResult> UpdateCandidate([FromQuery] string id, [FromBody] CandidateVM candidateVM)
		{
			try
			{
				var result = await _userService.UpdateCandidate(id, candidateVM);
				return Ok(new ApiResponse
				{
					Success = true,
					Message = "Hoàn thành",
					Code = StatusCodes.Status200OK,
					Data = result
				});
			}
			catch (ExceptionReturn e)
			{
				return Ok(new ApiResponse
				{
					Code = e.Code,
					Message = e.Message,
					Success = false
				});
			}
		}

		/// <summary>
		/// Sửa thông tin nhà tuyển dụng
		/// </summary>
		/// <param name="id"></param>
		/// <param name="employerVM"></param>
		/// <returns></returns>
		[HttpPut("update-employer")]
		public async Task<IActionResult> UpdateEmployer([FromQuery] string id, [FromBody] EmployerVM employerVM)
		{
			try
			{
				var result = await _userService.UpdateEmployer(id, employerVM);
				return Ok(new ApiResponse
				{
					Success = true,
					Message = "Hoàn thành",
					Code = StatusCodes.Status200OK,
					Data = result
				});
			}
			catch (ExceptionReturn e)
			{
				return Ok(new ApiResponse
				{
					Code = e.Code,
					Message = e.Message,
					Success = false
				});
			}
		}
	}
}
