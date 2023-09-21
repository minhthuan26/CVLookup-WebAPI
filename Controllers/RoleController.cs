using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.RoleService;
using CVLookup_WebAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CVLookup_WebAPI.Controllers
{
    [Route("api/[controller]")]
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
        [HttpPut("edit-role/{id}")]
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
        [HttpDelete("delete-role/{id}")]
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
    }
}
