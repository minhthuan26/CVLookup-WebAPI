﻿using AutoMapper;
using CVLookup_WebAPI.Middleware;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.UserRoleService;
using CVLookup_WebAPI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CVLookup_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [MiddlewareFilter(typeof(AuthMiddlewareBuilder))]
    [AuthorizationAttribute("Admin")]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;
        private readonly ILogger<UserRoleController> _logger;

        public UserRoleController(
            ILogger<UserRoleController> logger,
            IUserRoleService userRoleService
            )
        {
            _userRoleService = userRoleService;
            _logger = logger;
        }
        /// <summary>
        /// Lấy thông tin UserRole theo role name
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        [HttpGet("get-by-role-name")]
        public async Task<IActionResult> GetUserRoleByRoleName([FromQuery] string roleName)
        {
            var userRole = await _userRoleService.GetByRoleName(roleName);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Hoàn thành",
                Data = userRole
            });
        }

        /// <summary>
        /// Lấy thông tin UserRole theo UserId
        /// </summary>
        /// <param name="userId">ID của User</param>
        /// <returns>Thông tin UserRole</returns>
        [HttpGet("get-by-user-id")]
        public async Task<IActionResult> GetUserRoleByUserId([FromQuery] string userId)
        {
            var userRole = await _userRoleService.GetByUserId(userId);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Hoàn thành",
                Data = userRole
            });
        }

        /// <summary>
        /// Lấy thông tin UserRole theo RoleId
        /// </summary>
        /// <param name="roleId">ID của Role</param>
        /// <returns>Thông tin UserRole</returns>
        [HttpGet("get-by-role-id")]
        public async Task<IActionResult> GetUserRoleByRoleId([FromQuery] string roleId)
        {
            var userRole = await _userRoleService.GetByRoleId(roleId);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Hoàn thành",
                Data = userRole
            });
        }

        /// <summary>
        /// Thêm mới UserRole
        /// </summary>
        /// <param name="userRoleVM">Thông tin UserRole cần thêm</param>
        /// <returns>Thông tin UserRole đã thêm</returns>
        [HttpPost("create-user-role")]
        public async Task<IActionResult> AddUserRole([FromBody] UserRoleVM userRoleVM)
        {
            var newUserRole = await _userRoleService.Add(userRoleVM);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Hoàn thành",
                Data = newUserRole
            });
        }

        /// <summary>
        /// Xóa UserRole
        /// </summary>
        /// <param name="roleId">ID của Role</param>
        /// <param name="userId">ID của User</param>
        /// <returns>Thông tin UserRole đã xóa</returns>
        [HttpDelete("delete-user-role")]
        public async Task<IActionResult> DeleteUserRole([FromQuery] string roleId, [FromQuery] string userId)
        {
            var deletedUserRole = await _userRoleService.Delete(roleId, userId);
            return Ok(new ApiResponse
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Message = "Hoàn thành",
                Data = deletedUserRole
            });
        }

       
    }
}
