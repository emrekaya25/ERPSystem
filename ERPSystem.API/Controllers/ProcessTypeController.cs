using ERPSystem.Business.Abstract;
using ERPSystem.Business.Utilities.Attributes;
using ERPSystem.Business.Utilities.Validation.OfferValidator;
using ERPSystem.Business.Utilities.Validation.ProcessTypeValidator;
using ERPSystem.Entity.DTO.InvoiceDTO;
using ERPSystem.Entity.DTO.ProcessTypeDTO;
using ERPSystem.Entity.Entities;
using ERPSystem.Entity.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProcessTypeController : ControllerBase
    {
        private readonly IProcessTypeService _processTypeService;

        public ProcessTypeController(IProcessTypeService processTypeService)
        {
            _processTypeService = processTypeService;
        }
		[Authorize(Roles = "Admin,Müdür")]
		[HttpPost("/ProcessTypes")]
        public async Task<IActionResult> GetAllAsync(ProcessTypeDTORequest processTypeDTORequest)
        {
            var processTypes = await _processTypeService.GetAllAsync(processTypeDTORequest);

            return Ok(ApiResponse<List<ProcessTypeDTOResponse>>.SuccesWithData(processTypes));
        }
		[Authorize(Roles = "Admin,Müdür")]
		[HttpPost("/ProcessType")]
        public async Task<IActionResult> GetAsync(ProcessTypeDTORequest processTypeDTORequest)
        {
            var processType = await _processTypeService.GetAsync(processTypeDTORequest);

            return Ok(ApiResponse<ProcessTypeDTOResponse>.SuccesWithData(processType));
        }
		[Authorize(Roles = "Admin")]
		[HttpPost("/AddProcessType")]
        [ValidationFilter(typeof(ProcessTypeValidation))]
        public async Task<IActionResult> AddAsync(ProcessTypeDTORequest processTypeDTORequest)
        {
            var addedProcessType = await _processTypeService.AddAsync(processTypeDTORequest);

            return Ok(ApiResponse<ProcessTypeDTOResponse>.SuccesWithData(addedProcessType));
        }
		[Authorize(Roles = "Admin")]
		[HttpPost("/UpdateProcessType")]
        [ValidationFilter(typeof(ProcessTypeValidation))]
        public async Task<IActionResult> UpdateAsync(ProcessTypeDTORequest processTypeDTORequest)
        {
            await _processTypeService.UpdateAsync(processTypeDTORequest);
            return Ok(ApiResponse<ProcessTypeDTOResponse>.SuccesWithOutData());
        }
		[Authorize(Roles = "Admin")]
		[HttpPost("/DeleteProcessType")]
        public async Task<IActionResult> DeleteAsync(ProcessTypeDTORequest processTypeDTORequest)
        {
            await _processTypeService.DeleteAsync(processTypeDTORequest);
            return Ok(ApiResponse<ProcessTypeDTOResponse>.SuccesWithOutData());
        }
    }
}
