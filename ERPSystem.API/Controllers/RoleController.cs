using ERPSystem.Business.Abstract;
using ERPSystem.Business.Utilities.Attributes;
using ERPSystem.Business.Utilities.Validation.RoleValidator;
using ERPSystem.Entity.DTO.RequestDTO;
using ERPSystem.Entity.DTO.RoleDTO;
using ERPSystem.Entity.Entities;
using ERPSystem.Entity.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [Authorize(Roles = "Admin,Müdür,Çalışan")]
        [HttpPost("/Roles")]
        public async Task<IActionResult> GetAllAsync(RoleDTORequest roleDTORequest)
        {
            var roles = await _roleService.GetAllAsync(roleDTORequest);
            return Ok(ApiResponse<List<RoleDTOResponse>>.SuccesWithData(roles));
        }

        [Authorize(Roles = "Admin,Müdür")]
        [HttpPost("/Role")]
        public async Task<IActionResult> GetAsync(RoleDTORequest roleDTORequest)
        {
            var role = await _roleService.GetAsync(roleDTORequest);
            return Ok(ApiResponse<RoleDTOResponse>.SuccesWithData(role));
        }

        [Authorize(Roles = "Admin,Müdür")]
        [HttpPost("/AddRole")]
        [ValidationFilter(typeof(RoleValidation))]
        public async Task<IActionResult> AddAsync(RoleDTORequest roleDTORequest)
        {
            var addedRole = await _roleService.AddAsync(roleDTORequest);
            return Ok(ApiResponse<RoleDTOResponse>.SuccesWithData(addedRole));
        }

        [Authorize(Roles = "Admin,Müdür")]
        [HttpPost("/UpdateRole")]
        [ValidationFilter(typeof(RoleValidation))]
        public async Task<IActionResult> UpdateAsync(RoleDTORequest roleDTORequest)
        {
            await _roleService.UpdateAsync(roleDTORequest);
            return Ok(ApiResponse<RoleDTOResponse>.SuccesWithOutData());
        }

        [Authorize(Roles = "Admin,Müdür")]
        [HttpPost("/DeleteRole")]
        public async Task<IActionResult> DeleteAsync(RoleDTORequest roleDTORequest)
        {
            await _roleService.DeleteAsync(roleDTORequest);
            return Ok(ApiResponse<RoleDTOResponse>.SuccesWithOutData());
        }
    }
}
