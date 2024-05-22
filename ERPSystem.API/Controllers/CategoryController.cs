using ERPSystem.Business.Abstract;
using ERPSystem.Business.Utilities.Attributes;
using ERPSystem.Business.Utilities.Validation.CategoryValidator;
using ERPSystem.Entity.DTO.CategoryDTO;
using ERPSystem.Entity.DTO.CompanyDTO;
using ERPSystem.Entity.DTO.DepartmentDTO;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("/Categories")]
        public async Task<IActionResult> GetAllAsync(CategoryDTORequest categoryDTORequest)
        {
            var categories = await _categoryService.GetAllAsync(categoryDTORequest);
            return Ok(ApiResponse<List<CategoryDTOResponse>>.SuccesWithData(categories));
        }

        [HttpPost("/Category")]
        public async Task<IActionResult> GetAsync(CategoryDTORequest categoryDTORequest)
        {
            var category = await _categoryService.GetAsync(categoryDTORequest);
            return Ok(ApiResponse<CategoryDTOResponse>.SuccesWithData(category));
        }


        [HttpPost("/AddCategory")]
        [ValidationFilter(typeof(CategoryValidation))]
        public async Task<IActionResult> AddAsync(CategoryDTORequest categoryDTORequest)
        {
            var category = await _categoryService.AddAsync(categoryDTORequest);
            return Ok(ApiResponse<CategoryDTOResponse>.SuccesWithData(category));
        }


        [HttpPost("/UpdateCategory")]
        [ValidationFilter(typeof(CategoryValidation))]
        public async Task<IActionResult> UpdateAsync(CategoryDTORequest categoryDTORequest)
        {
            await _categoryService.UpdateAsync(categoryDTORequest);
            return Ok(ApiResponse<CategoryDTOResponse>.SuccesWithOutData());
        }

        [HttpPost("/DeleteCategory")]
        public async Task<IActionResult> DeleteAsync(CategoryDTORequest categoryDTORequest)
        {
            await _categoryService.DeleteAsync(categoryDTORequest);
            return Ok(ApiResponse<CategoryDTOResponse>.SuccesWithOutData());
        }
    }
}
