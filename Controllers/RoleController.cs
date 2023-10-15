using CVLookup_WebAPI.Middleware;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.RoleService;
using CVLookup_WebAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CVLookup_WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
    [AuthorizationAttribute("Admin")]
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
            var roles = await _roleService.RoleList();
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Hoàn thành",
                Data = roles
            });
        }
        /// <summary>
        /// Tạo mới role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost("create-role")]
        public async Task<IActionResult> AddRole([FromBody] RoleVM role)
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
        /// <summary>
        /// Sửa role
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedRole"></param>
        /// <returns></returns>
        [HttpPatch("update-role")]
        public async Task<IActionResult> UpdateRole([FromQuery] string id, [FromBody] RoleVM updatedRole)
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
        /// <summary>
        /// Xoá role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete-role")]
        public async Task<IActionResult> DeleteRole([FromQuery] string id)
        {
            var deletedRole = await _roleService.Delete(id);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Hoàn thành",
                Data = deletedRole
            });
        }

        /// <summary>
        /// Lấy phân quyền theo role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-role-by-id")]
        public async Task<IActionResult> GetRoleById([FromQuery] string id)
        {
            var result = await _roleService.GetRoleById(id);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = "Hoàn thành"
            });
        }

        /// <summary>
        /// Lấy phân quyền theo tên
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpGet("get-role-by-value")]
        public async Task<IActionResult> GetRoleByValue([FromQuery] string role)
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
    }
}
