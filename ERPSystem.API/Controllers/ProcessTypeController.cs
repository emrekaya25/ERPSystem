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
    [Authorize(Roles = "Admin,Müdür")]
    public class ProcessTypeController : ControllerBase
    {
        private readonly IProcessTypeService _processTypeService;

        public ProcessTypeController(IProcessTypeService processTypeService)
        {
            _processTypeService = processTypeService;
        }

        [HttpPost("/ProcessTypes")]
        public async Task<IActionResult> GetAllAsync(ProcessTypeDTORequest processTypeDTORequest)
        {
            var processTypes = await _processTypeService.GetAllAsync(processTypeDTORequest);

            return Ok(ApiResponse<List<ProcessTypeDTOResponse>>.SuccesWithData(processTypes));
        }

        [HttpPost("/ProcessType")]
        public async Task<IActionResult> GetAsync(ProcessTypeDTORequest processTypeDTORequest)
        {
            var processType = await _processTypeService.GetAsync(processTypeDTORequest);

            return Ok(ApiResponse<ProcessTypeDTOResponse>.SuccesWithData(processType));
        }

        [HttpPost("/AddProcessType")]
        [ValidationFilter(typeof(ProcessTypeValidation))]
        public async Task<IActionResult> AddAsync(ProcessTypeDTORequest processTypeDTORequest)
        {
            var addedProcessType = await _processTypeService.AddAsync(processTypeDTORequest);

            return Ok(ApiResponse<ProcessTypeDTOResponse>.SuccesWithData(addedProcessType));
        }

        [HttpPost("/UpdateProcessType")]
        [ValidationFilter(typeof(ProcessTypeValidation))]
        public async Task<IActionResult> UpdateAsync(ProcessTypeDTORequest processTypeDTORequest)
        {
            await _processTypeService.UpdateAsync(processTypeDTORequest);
            return Ok(ApiResponse<ProcessTypeDTOResponse>.SuccesWithOutData());
        }

        [HttpPost("/DeleteProcessType")]
        public async Task<IActionResult> DeleteAsync(ProcessTypeDTORequest processTypeDTORequest)
        {
            await _processTypeService.DeleteAsync(processTypeDTORequest);
            return Ok(ApiResponse<ProcessTypeDTOResponse>.SuccesWithOutData());
        }
    }
}
