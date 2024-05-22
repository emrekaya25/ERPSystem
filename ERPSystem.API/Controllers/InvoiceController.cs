using Azure.Core;
using ERPSystem.Business.Abstract;
using ERPSystem.Business.Utilities.Attributes;
using ERPSystem.Business.Utilities.Validation.DepartmentValidator;
using ERPSystem.Business.Utilities.Validation.InvoiceValidator;
using ERPSystem.Entity.DTO.InvoiceDTO;
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
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost("/Invoices")]
        public async Task<IActionResult> GetAllAsync(InvoiceDTORequest invoiceDTORequest)
        {
            var invoices = await _invoiceService.GetAllAsync(invoiceDTORequest);

            return Ok(ApiResponse<List<InvoiceDTOResponse>>.SuccesWithData(invoices));
        }

        [HttpPost("/InvoicesByDate")]
        public async Task<IActionResult> GetAllAsyncByDate(string datefilter)
        {
            var invoices = await _invoiceService.GetAllAsyncByDate(datefilter);

            return Ok(ApiResponse<List<InvoiceDTOResponse>>.SuccesWithData(invoices));
        }



        [HttpPost("/Invoice")]
        public async Task<IActionResult> GetAsync(InvoiceDTORequest invoiceDTORequest)
        {
            var invoice = await _invoiceService.GetAsync(invoiceDTORequest);

            return Ok(ApiResponse<InvoiceDTOResponse>.SuccesWithData(invoice));
        }

        [HttpPost("/AddInvoice")]
        [ValidationFilter(typeof(InvoiceValidation))]
        public async Task<IActionResult> AddAsync(InvoiceDTORequest invoiceDTORequest)
        {
            var addedInvoice = await _invoiceService.AddAsync(invoiceDTORequest);

            return Ok(ApiResponse<InvoiceDTOResponse>.SuccesWithData(addedInvoice));
        }

        [HttpPost("/UpdateInvoice")]
        [ValidationFilter(typeof(InvoiceValidation))]
        public async Task<IActionResult> UpdateAsync(InvoiceDTORequest invoiceDTORequest)
        {
            await _invoiceService.UpdateAsync(invoiceDTORequest);
            return Ok(ApiResponse<InvoiceDTOResponse>.SuccesWithOutData());
        }

        [HttpPost("/DeleteInvoice")]
        public async Task<IActionResult> DeleteAsync(InvoiceDTORequest invoiceDTORequest)
        {
            await _invoiceService.DeleteAsync(invoiceDTORequest);
            return Ok(ApiResponse<InvoiceDTOResponse>.SuccesWithOutData());
        }

    }
}
