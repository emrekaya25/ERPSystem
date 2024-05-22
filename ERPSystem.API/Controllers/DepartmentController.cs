using ERPSystem.Business.Abstract;
using ERPSystem.Business.Utilities.Attributes;
using ERPSystem.Business.Utilities.Validation.CompanyValidator;
using ERPSystem.Business.Utilities.Validation.DepartmentValidator;
using ERPSystem.Entity.DTO.CategoryDTO;
using ERPSystem.Entity.DTO.DepartmentDTO;
using ERPSystem.Entity.Entities;
using ERPSystem.Entity.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [Authorize(Roles = "Admin,Müdür,Çalışan")]
        [HttpPost("/Departments")]
        public async Task<IActionResult> GetAllAsync(DepartmentDTORequest departmentDTORequest)
        {
            var departments = await _departmentService.GetAllAsync(departmentDTORequest);
            return Ok(ApiResponse<List<DepartmentDTOResponse>>.SuccesWithData(departments));
        }

        [Authorize(Roles = "Admin,Müdür")]
        [HttpPost("/Department")]
        public async Task<IActionResult> GetAsync(DepartmentDTORequest departmentDTORequest)
        {
            var department = await _departmentService.GetAsync(departmentDTORequest);
            return Ok(ApiResponse<DepartmentDTOResponse>.SuccesWithData(department));
        }

        [Authorize(Roles = "Admin,Müdür")]
        [HttpPost("/AddDepartment")]
        [ValidationFilter(typeof(DepartmentValidation))]
        public async Task<IActionResult> AddAsync(DepartmentDTORequest departmentDTORequest)
        {
            var department = await _departmentService.AddAsync(departmentDTORequest);
            return Ok(ApiResponse<DepartmentDTOResponse>.SuccesWithData(department));
        }

        [Authorize(Roles = "Admin,Müdür")]
        [HttpPost("/UpdateDepartment")]
        [ValidationFilter(typeof(DepartmentValidation))]
        public async Task<IActionResult> UpdateAsync(DepartmentDTORequest departmentDTORequest)
        {
            await _departmentService.UpdateAsync(departmentDTORequest);
            return Ok(ApiResponse<DepartmentDTOResponse>.SuccesWithOutData());
        }

        [Authorize(Roles = "Admin,Müdür")]
        [HttpPost("/DeleteDepartment")]
        public async Task<IActionResult> DeleteAsync(DepartmentDTORequest departmentDTORequest)
        {
            await _departmentService.DeleteAsync(departmentDTORequest);
            return Ok(ApiResponse<DepartmentDTOResponse>.SuccesWithOutData());
        }
    }
}
