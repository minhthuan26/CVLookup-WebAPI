using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.RoleService;
using CVLookup_WebAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CVLookup_WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<RoleController> _logger;

        public RoleController(ILogger<RoleController> logger, IRoleService roleService)
        {
            _roleService = roleService;
            _logger = logger;
        }

        /// <summary>
        /// Lấy danh sách các role
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-roles")]
        public async Task<IActionResult> GetRoleList()
        {
            try
            {
                var roles = await _roleService.RoleList();
                return Ok(new ApiResponse
                {
                    Success = true,
                    Code = StatusCodes.Status200OK,
                    Message = "Hoàn thành",
                    Data = roles
                });
            }
            catch (ExceptionReturn ex)
            {
                return Ok(new ApiResponse
                {
                    Success = false,
                    Message = ex.Message,
                    Code = ex.Code
                });
            }
        }
        /// <summary>
        /// Tạo mới role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost("create-role")]
        public async Task<IActionResult> AddRole([FromBody] RoleVM role)
        {
            try
            {
                var newRole = await _roleService.Add(role);
                return Ok(new ApiResponse
                {
                    Success = true,
                    Code = StatusCodes.Status200OK,
                    Message = "Hoàn thành",
                    Data = newRole
                });
            }
            catch (ExceptionReturn ex)
            {
                return Ok(new ApiResponse { Success = false, Message = ex.Message, Code = StatusCodes.Status500InternalServerError });
            }
        }
        /// <summary>
        /// Sửa role
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedRole"></param>
        /// <returns></returns>
        [HttpPut("edit-role/{role}")]
        public async Task<IActionResult> UpdateRole(string id, [FromBody] RoleVM updatedRole)
        {
            try
            {
                var role = await _roleService.Update(id, updatedRole);
                return Ok(new ApiResponse
                {
                    Success = true,
                    Code = StatusCodes.Status200OK,
                    Message = "Hoàn thành",
                    Data = role
                });
            }
            catch (ExceptionReturn ex)
            {
                return Ok(new ApiResponse { Success = false, Message = ex.Message, Code = StatusCodes.Status500InternalServerError });
            }
        }
        /// <summary>
        /// Xoá role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete-role/{role}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            try
            {
                var deletedRole = await _roleService.Delete(id);
                return Ok(new ApiResponse { Success = true, Code = StatusCodes.Status200OK, Message = "Hoàn thành", Data = deletedRole });
            }
            catch (ExceptionReturn ex)
            {
                return Ok(new ApiResponse { Success = false, Message = ex.Message, Code = StatusCodes.Status500InternalServerError });
            }
        }

		/// <summary>
		/// Lấy phân quyền theo role
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("get-role-by-id")]
		public async Task<IActionResult> getRoleById([FromQuery] string id)
        {
            try
            {
                var result = await _roleService.GetRoleById(id);
                return Ok(new ApiResponse
                {
                    Success = true,
                    Code = StatusCodes.Status200OK,
                    Data = result,
                    Message = "Hoàn thành"
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

        /// <summary>
        /// Lấy phân quyền theo tên
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpGet("get-role-by-value")]
		public async Task<IActionResult> getRoleByValue([FromQuery] string role)
		{
			try
			{
				var result = await _roleService.GetRoleByValue(role);
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
