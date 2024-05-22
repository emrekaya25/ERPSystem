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
    [Authorize(Roles = "Admin,Müdür,Çalışan")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpPost("/Statuses")]
        public async Task<IActionResult> GetAllAsync(StatusDTORequest statusDTORequest)
        {
            var statuses = await _statusService.GetAllAsync(statusDTORequest);
            return Ok(ApiResponse<List<StatusDTOResponse>>.SuccesWithData(statuses));
        }

        [HttpPost("/Status")]
        public async Task<IActionResult> GetAsync(StatusDTORequest statusDTORequest)
        {
            var status = await _statusService.GetAsync(statusDTORequest);
            return Ok(ApiResponse<StatusDTOResponse>.SuccesWithData(status));
        }

        [HttpPost("/AddStatus")]
        [ValidationFilter(typeof(StatusValidation))]
        public async Task<IActionResult> AddAsync(StatusDTORequest statusDTORequest)
        {
            var addedStatus = await _statusService.AddAsync(statusDTORequest);
            return Ok(ApiResponse<StatusDTOResponse>.SuccesWithData(addedStatus));
        }

        [HttpPost("/UpdateStatus")]
        [ValidationFilter(typeof(StatusValidation))]
        public async Task<IActionResult> UpdateAsync(StatusDTORequest statusDTORequest)
        {
            await _statusService.UpdateAsync(statusDTORequest);
            return Ok(ApiResponse<StatusDTOResponse>.SuccesWithOutData());
        }

        [HttpPost("/DeleteStatus")]
        public async Task<IActionResult> DeleteAsync(StatusDTORequest statusDTORequest)
        {
            await _statusService.DeleteAsync(statusDTORequest);
            return Ok(ApiResponse<StatusDTOResponse>.SuccesWithOutData());
        }
    }
}
