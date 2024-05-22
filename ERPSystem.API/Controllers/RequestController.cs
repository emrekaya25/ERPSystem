using ERPSystem.Business.Abstract;
using ERPSystem.Business.Utilities.Attributes;
using ERPSystem.Business.Utilities.Validation.ProductValidator;
using ERPSystem.Business.Utilities.Validation.RequestValidator;
using ERPSystem.Entity.DTO.ProductDTO;
using ERPSystem.Entity.DTO.RequestDTO;
using ERPSystem.Entity.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService productService)
        {
            _requestService = productService;
        }
        [Authorize(Roles = "Admin,Müdür,Çalışan")]
        [HttpPost("/Requests")]
        public async Task<IActionResult> GetAllAsync(RequestDTORequest requestDTORequest)
        {
            var requests = await _requestService.GetAllAsync(requestDTORequest);
            return Ok(ApiResponse<List<RequestDTOResponse>>.SuccesWithData(requests));
        }

        [Authorize(Roles = "Admin,Müdür")]
        [HttpPost("/Request")]
        public async Task<IActionResult> GetAsync(RequestDTORequest requestDTORequest)
        {
            var request = await _requestService.GetAsync(requestDTORequest);
            return Ok(ApiResponse<RequestDTOResponse>.SuccesWithData(request));
        }

        [Authorize(Roles = "Admin,Müdür,Çalışan")]
        [ValidationFilter(typeof(RequestValidation))]
        [HttpPost("/AddRequest")]
        public async Task<IActionResult> AddAsync(RequestDTORequest requestDTORequest)
        {
            var addedRequest = await _requestService.AddAsync(requestDTORequest);
            return Ok(ApiResponse<RequestDTOResponse>.SuccesWithData(addedRequest));
        }

        [Authorize(Roles = "Admin,Müdür,Çalışan")]
        [HttpPost("/UpdateRequest")]
        [ValidationFilter(typeof(RequestValidation))]
        public async Task<IActionResult> UpdateAsync(RequestDTORequest requestDTORequest)
        {
            await _requestService.UpdateAsync(requestDTORequest);
            return Ok(ApiResponse<RequestDTOResponse>.SuccesWithOutData());
        }

        [Authorize(Roles = "Admin,Müdür")]
        [HttpPost("/DeleteRequest")]
        public async Task<IActionResult> DeleteAsync(RequestDTORequest requestDTORequest)
        {
            await _requestService.DeleteAsync(requestDTORequest);
            return Ok(ApiResponse<RequestDTOResponse>.SuccesWithOutData());
        }
    }
}
