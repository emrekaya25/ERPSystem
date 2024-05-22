using ERPSystem.Business.Abstract;
using ERPSystem.Business.Utilities.Attributes;
using ERPSystem.Business.Utilities.Validation.StockDetailValidator;
using ERPSystem.Business.Utilities.Validation.StockValidator;
using ERPSystem.Entity.DTO.StockDetailDTO;
using ERPSystem.Entity.DTO.StockDTO;
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
    public class StockDetailController : ControllerBase
    {
        private readonly IStockDetailService _stockDetailService;

        public StockDetailController(IStockDetailService stockDetailService)
        {
            _stockDetailService = stockDetailService;
        }

        [HttpPost("/StockDetails")]
        public async Task<IActionResult> GetAllAsync(StockDetailDTORequest stockDetailDTORequest)
        {
            var stockDetails = await _stockDetailService.GetAllAsync(stockDetailDTORequest);
            return Ok(ApiResponse<List<StockDetailDTOResponse>>.SuccesWithData(stockDetails));
        }

        [HttpPost("/StockDetail")]
        public async Task<IActionResult> GetAsync(StockDetailDTORequest stockDetailDTORequest)
        {
            var stockDetail = await _stockDetailService.GetAsync(stockDetailDTORequest);
            return Ok(ApiResponse<StockDetailDTOResponse>.SuccesWithData(stockDetail));
        }

        [HttpPost("/AddStockDetail")]
        [ValidationFilter(typeof(StockDetailValidation))]
        public async Task<IActionResult> AddAsync(StockDetailDTORequest stockDetailDTORequest)
        {
            var addedStockDetail = await _stockDetailService.AddAsync(stockDetailDTORequest);
            return Ok(ApiResponse<StockDetailDTOResponse>.SuccesWithData(addedStockDetail));
        }

        [HttpPost("/UpdateStockDetail")]
        [ValidationFilter(typeof(StockDetailValidation))]
        public async Task<IActionResult> UpdateAsync(StockDetailDTORequest stockDetailDTORequest)
        {
            await _stockDetailService.UpdateAsync(stockDetailDTORequest);
            return Ok(ApiResponse<StockDetailDTOResponse>.SuccesWithOutData());
        }

        [HttpPost("/DeleteStockDetail")]
        public async Task<IActionResult> DeleteAsync(StockDetailDTORequest stockDetailDTORequest)
        {
            await _stockDetailService.DeleteAsync(stockDetailDTORequest);
            return Ok(ApiResponse<StockDetailDTOResponse>.SuccesWithOutData());
        }
    }
}
