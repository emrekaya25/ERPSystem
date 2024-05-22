using ERPSystem.Business.Abstract;
using ERPSystem.Business.Utilities.Attributes;
using ERPSystem.Business.Utilities.Validation.InvoiceValidator;
using ERPSystem.Entity.DTO.InvoiceDetailDTO;
using ERPSystem.Entity.DTO.InvoiceDTO;
using ERPSystem.Entity.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Müdür")]
    public class InvoiceDetailController : ControllerBase
    {
        private readonly IInvoiceDetailService _invoiceDetailService;

        public InvoiceDetailController(IInvoiceDetailService invoiceDetailService)
        {
            _invoiceDetailService = invoiceDetailService;
        }

        [HttpPost("/InvoiceDetails")]
        public async Task<IActionResult> GetAllAsync(InvoiceDetailDTORequest invoiceDetailDTORequest)
        {
            var invoiceDetails = await _invoiceDetailService.GetAllAsync(invoiceDetailDTORequest);

            return Ok(ApiResponse<List<InvoiceDetailDTOResponse>>.SuccesWithData(invoiceDetails));
        }


        [HttpPost("/InvoiceDetail")]
        public async Task<IActionResult> GetAsync(InvoiceDetailDTORequest invoiceDetailDTORequest)
        {
            var invoiceDetail = await _invoiceDetailService.GetAsync(invoiceDetailDTORequest);

            return Ok(ApiResponse<InvoiceDetailDTOResponse>.SuccesWithData(invoiceDetail));
        }

        [HttpPost("/AddInvoiceDetail")]
        public async Task<IActionResult> AddAsync(InvoiceDetailDTORequest invoiceDetailDTORequest)
        {
            var addedInvoiceDetail = await _invoiceDetailService.AddAsync(invoiceDetailDTORequest);

            return Ok(ApiResponse<InvoiceDetailDTOResponse>.SuccesWithData(addedInvoiceDetail));
        }

        

        [HttpPost("/UpdateInvoiceDetail")]
        public async Task<IActionResult> UpdateAsync(InvoiceDetailDTORequest invoiceDetailDTORequest)
        {
            await _invoiceDetailService.UpdateAsync(invoiceDetailDTORequest);
            return Ok(ApiResponse<InvoiceDetailDTOResponse>.SuccesWithOutData());
        }

        [HttpPost("/DeleteInvoiceDetail")]
        public async Task<IActionResult> DeleteAsync(InvoiceDetailDTORequest invoiceDetailDTORequest)
        {
            await _invoiceDetailService.DeleteAsync(invoiceDetailDTORequest);
            return Ok(ApiResponse<InvoiceDetailDTOResponse>.SuccesWithOutData());
        }
    }
}
