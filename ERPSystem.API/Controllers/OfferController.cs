using ERPSystem.Business.Abstract;
using ERPSystem.Business.Utilities.Attributes;
using ERPSystem.Business.Utilities.Validation.InvoiceValidator;
using ERPSystem.Business.Utilities.Validation.OfferValidator;
using ERPSystem.Entity.DTO.OfferDTO;
using ERPSystem.Entity.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Müdür")]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpPost("/Offers")]
        public async Task<IActionResult> GetAllAsync(OfferDTORequest offerDTORequest)
        {
            var offers = await _offerService.GetAllAsync(offerDTORequest);
            return Ok(ApiResponse<List<OfferDTOResponse>>.SuccesWithData(offers));
        }

        [HttpPost("/Offer")]
        public async Task<IActionResult> GetAsync(OfferDTORequest offerDTORequest)
        {
            var offer = await _offerService.GetAsync(offerDTORequest);
            return Ok(ApiResponse<OfferDTOResponse>.SuccesWithData(offer));
        }

        [HttpPost("/AddOffer")]
        [ValidationFilter(typeof(OfferValidation))]
        public async Task<IActionResult> AddAsync(OfferDTORequest offerDTORequest)
        {
            var addedOffer = await _offerService.AddAsync(offerDTORequest);
            return Ok(ApiResponse<OfferDTOResponse>.SuccesWithData(addedOffer));
        }

        [HttpPost("/UpdateOffer")]
        [ValidationFilter(typeof(OfferValidation))]
        public async Task<IActionResult> UpdateAsync(OfferDTORequest offerDTORequest)
        {
            await _offerService.UpdateAsync(offerDTORequest);
            return Ok(ApiResponse<OfferDTOResponse>.SuccesWithOutData());
        }

        [HttpPost("/DeleteOffer")]
        public async Task<IActionResult> DeleteAsync(OfferDTORequest offerDTORequest)
        {
            await _offerService.DeleteAsync(offerDTORequest);
            return Ok(ApiResponse<OfferDTOResponse>.SuccesWithOutData());

        }

    }
}
