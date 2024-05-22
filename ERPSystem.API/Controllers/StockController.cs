using ERPSystem.Business.Abstract;
using ERPSystem.Business.Utilities.Attributes;
using ERPSystem.Business.Utilities.Validation.StatusValidator;
using ERPSystem.Business.Utilities.Validation.StockValidator;
using ERPSystem.Entity.DTO.StatusDTO;
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
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpPost("/Stocks")]
        public async Task<IActionResult> GetAllAsync(StockDTORequest stockDTORequest)
        {
            var stocks = await _stockService.GetAllAsync(stockDTORequest);
            return Ok(ApiResponse<List<StockDTOResponse>>.SuccesWithData(stocks));
        }

        [HttpPost("/Stock")]
        public async Task<IActionResult> GetAsync(StockDTORequest stockDTORequest)
        {
            var stock = await _stockService.GetAsync(stockDTORequest);
            return Ok(ApiResponse<StockDTOResponse>.SuccesWithData(stock));
        }

        [HttpPost("/AddStock")]
        [ValidationFilter(typeof(StockValidation))]
        public async Task<IActionResult> AddAsync(StockDTORequest stockDTORequest)
        {
            var addedStock = await _stockService.AddAsync(stockDTORequest);
            return Ok(ApiResponse<StockDTOResponse>.SuccesWithData(addedStock));
        }

        [HttpPost("/UpdateStock")]
        [ValidationFilter(typeof(StockValidation))]
        public async Task<IActionResult> UpdateAsync(StockDTORequest stockDTORequest)
        {
            await _stockService.UpdateAsync(stockDTORequest);
            return Ok(ApiResponse<StockDTOResponse>.SuccesWithOutData());
        }

        [HttpPost("/DeleteStock")]
        public async Task<IActionResult> DeleteAsync(StockDTORequest stockDTORequest)
        {
            await _stockService.DeleteAsync(stockDTORequest);
            return Ok(ApiResponse<StockDTOResponse>.SuccesWithOutData());
        }
    }
}
