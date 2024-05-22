using ERPSystem.Business.Abstract;
using ERPSystem.Business.Utilities.Attributes;
using ERPSystem.Business.Utilities.Validation.ProcessTypeValidator;
using ERPSystem.Business.Utilities.Validation.ProductValidator;
using ERPSystem.Entity.DTO.ProductDTO;
using ERPSystem.Entity.Entities;
using ERPSystem.Entity.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [Authorize(Roles = "Admin,Müdür,Çalışan")]
        [HttpPost("/Products")]
        public async Task<IActionResult> GetAllAsync(ProductDTORequest productDTORequest)
        {
            var products = await _productService.GetAllAsync(productDTORequest);
            return Ok(ApiResponse<List<ProductDTOResponse>>.SuccesWithData(products));
        }

        [Authorize(Roles = "Admin,Müdür")]
        [HttpPost("/Product")]
        public async Task<IActionResult> GetAsync(ProductDTORequest productDTORequest)
        {
            var product = await _productService.GetAsync(productDTORequest);
            return Ok(ApiResponse<ProductDTOResponse>.SuccesWithData(product));
        }

        [Authorize(Roles = "Admin,Müdür")]
        [HttpPost("/AddProduct")]
        [ValidationFilter(typeof(ProductValidation))]
        public async Task<IActionResult> AddAsync(ProductDTORequest productDTORequest)
        {
            var addedProduct = await _productService.AddAsync(productDTORequest);
            return Ok(ApiResponse<ProductDTOResponse>.SuccesWithData(addedProduct));
        }

        [Authorize(Roles = "Admin,Müdür")]
        [HttpPost("/UpdateProduct")]
        [ValidationFilter(typeof(ProductValidation))]
        public async Task<IActionResult> UpdateAsync(ProductDTORequest productDTORequest)
        {
            await _productService.UpdateAsync(productDTORequest);
            return Ok(ApiResponse<ProductDTOResponse>.SuccesWithOutData());
        }

        [Authorize(Roles = "Admin,Müdür")]
        [HttpPost("/DeleteProduct")]
        public async Task<IActionResult> DeleteAsync(ProductDTORequest productDTORequest)
        {
            await _productService.DeleteAsync(productDTORequest);
            return Ok(ApiResponse<ProductDTOResponse>.SuccesWithOutData());
        }
    }
}
