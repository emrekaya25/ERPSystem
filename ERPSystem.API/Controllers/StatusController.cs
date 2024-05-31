using ERPSystem.Business.Abstract;
using ERPSystem.Business.Utilities.Attributes;
using ERPSystem.Business.Utilities.Validation.RoleValidator;
using ERPSystem.Business.Utilities.Validation.StatusValidator;
using ERPSystem.Entity.DTO.RoleDTO;
using ERPSystem.Entity.DTO.StatusDTO;
using ERPSystem.Entity.Entities;
using ERPSystem.Entity.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }
		[Authorize(Roles = "Admin,Müdür,Çalışan")]
		[HttpPost("/Statuses")]
        public async Task<IActionResult> GetAllAsync(StatusDTORequest statusDTORequest)
        {
            var statuses = await _statusService.GetAllAsync(statusDTORequest);
            return Ok(ApiResponse<List<StatusDTOResponse>>.SuccesWithData(statuses));
        }
		[Authorize(Roles = "Admin,Müdür,Çalışan")]
		[HttpPost("/Status")]
        public async Task<IActionResult> GetAsync(StatusDTORequest statusDTORequest)
        {
            var status = await _statusService.GetAsync(statusDTORequest);
            return Ok(ApiResponse<StatusDTOResponse>.SuccesWithData(status));
        }
		[Authorize(Roles = "Admin")]
		[HttpPost("/AddStatus")]
        [ValidationFilter(typeof(StatusValidation))]
        public async Task<IActionResult> AddAsync(StatusDTORequest statusDTORequest)
        {
            var addedStatus = await _statusService.AddAsync(statusDTORequest);
            return Ok(ApiResponse<StatusDTOResponse>.SuccesWithData(addedStatus));
        }
		[Authorize(Roles = "Admin")]
		[HttpPost("/UpdateStatus")]
        [ValidationFilter(typeof(StatusValidation))]
        public async Task<IActionResult> UpdateAsync(StatusDTORequest statusDTORequest)
        {
            await _statusService.UpdateAsync(statusDTORequest);
            return Ok(ApiResponse<StatusDTOResponse>.SuccesWithOutData());
        }
		[Authorize(Roles = "Admin")]
		[HttpPost("/DeleteStatus")]
        public async Task<IActionResult> DeleteAsync(StatusDTORequest statusDTORequest)
        {
            await _statusService.DeleteAsync(statusDTORequest);
            return Ok(ApiResponse<StatusDTOResponse>.SuccesWithOutData());
        }
    }
}
