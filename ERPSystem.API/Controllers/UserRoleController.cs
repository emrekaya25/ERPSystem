using ERPSystem.Business.Abstract;
using ERPSystem.Business.Utilities.Attributes;
using ERPSystem.Business.Utilities.Validation.UserRoleValidator;
using ERPSystem.Business.Utilities.Validation.UserValidator;
using ERPSystem.Entity.DTO.UserDTO;
using ERPSystem.Entity.DTO.UserRoleDTO;
using ERPSystem.Entity.Entities;
using ERPSystem.Entity.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Müdür")]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpPost("/UserRoles")]
        public async Task<IActionResult> GetAllAsync(UserRoleDTORequest userRoleDTORequest)
        {
            var userRoles = await _userRoleService.GetAllAsync(userRoleDTORequest);
            return Ok(ApiResponse<List<UserRoleDTOResponse>>.SuccesWithData(userRoles));
        }

        [HttpPost("/UserRole")]
        public async Task<IActionResult> GetAsync(UserRoleDTORequest userRoleDTORequest)
        {
            var userRole = await _userRoleService.GetAsync(userRoleDTORequest);
            return Ok(ApiResponse<UserRoleDTOResponse>.SuccesWithData(userRole));
        }

        [HttpPost("/AddUserRole")]
        [ValidationFilter(typeof(UserRoleValidation))]
        public async Task<IActionResult> AddAsync(UserRoleDTORequest userRoleDTORequest)
        {
            var addedUserRole = await _userRoleService.AddAsync(userRoleDTORequest);
            return Ok(ApiResponse<UserRoleDTOResponse>.SuccesWithData(addedUserRole));
        }

        [HttpPost("/UpdateUserRole")]
        [ValidationFilter(typeof(UserRoleValidation))]
        public async Task<IActionResult> UpdateAsync(UserRoleDTORequest userRoleDTORequest)
        {
            await _userRoleService.UpdateAsync(userRoleDTORequest);
            return Ok(ApiResponse<UserDTOResponse>.SuccesWithOutData());
        }

        [HttpPost("/DeleteUserRole")]
        public async Task<IActionResult> DeleteAsync(UserRoleDTORequest userRoleDTORequest)
        {
            await _userRoleService.DeleteAsync(userRoleDTORequest);
            return Ok(ApiResponse<UserDTOResponse>.SuccesWithOutData());
        }
    }
}
