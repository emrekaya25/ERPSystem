using ERPSystem.Business.Abstract;
using ERPSystem.Business.Utilities.Attributes;
using ERPSystem.Business.Utilities.Validation.CategoryValidator;
using ERPSystem.Business.Utilities.Validation.CompanyValidator;
using ERPSystem.DataAccess.Abstract;
using ERPSystem.Entity.DTO.CategoryDTO;
using ERPSystem.Entity.DTO.CompanyDTO;
using ERPSystem.Entity.Entities;
using ERPSystem.Entity.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin,Müdür")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("/Companies")]
        public async Task<IActionResult> GetAllAsync(CompanyDTORequest companyDTORequest)
        {
            var companies = await _companyService.GetAllAsync(companyDTORequest);
            return Ok(ApiResponse<List<CompanyDTOResponse>>.SuccesWithData(companies));
        }

        [HttpPost("/Company")]
        public async Task<IActionResult> GetAsync(CompanyDTORequest companyDTORequest)
        {
            var company = await _companyService.GetAsync(companyDTORequest);
            return Ok(ApiResponse<CompanyDTOResponse>.SuccesWithData(company));
        }


        [HttpPost("/AddCompany")]
        [ValidationFilter(typeof(CompanyValidation))]
        public async Task<IActionResult> AddAsync(CompanyDTORequest companyDTORequest)
        {
            var company = await _companyService.AddAsync(companyDTORequest);
            return Ok(ApiResponse<CompanyDTOResponse>.SuccesWithData(company));
        }

        [HttpPost("/UpdateCompany")]
        [ValidationFilter(typeof(CompanyValidation))]
        public async Task<IActionResult> UpdateAsync(CompanyDTORequest companyDTORequest)
        {
            await _companyService.UpdateAsync(companyDTORequest);
            return Ok(ApiResponse<CompanyDTOResponse>.SuccesWithOutData());
        }

        [HttpPost("/DeleteCompany")]
        public async Task<IActionResult> DeleteAsync(CompanyDTORequest companyDTORequest)
        {
            await _companyService.DeleteAsync(companyDTORequest);
            return Ok(ApiResponse<CompanyDTOResponse>.SuccesWithOutData());
        }
    }
}
