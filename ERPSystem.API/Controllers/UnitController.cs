﻿using ERPSystem.Business.Abstract;
using ERPSystem.Business.Utilities.Attributes;
using ERPSystem.Business.Utilities.Validation.StockDetailValidator;
using ERPSystem.Business.Utilities.Validation.UnitValidator;
using ERPSystem.Entity.DTO.StockDetailDTO;
using ERPSystem.Entity.DTO.UnitDTO;
using ERPSystem.Entity.Entities;
using ERPSystem.Entity.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }
		[Authorize(Roles = "Admin,Müdür,Çalışan")]
		[HttpPost("/Units")]
        public async Task<IActionResult> GetAllAsync(UnitDTORequest unitDTORequest)
        {
            var unitDetails = await _unitService.GetAllAsync(unitDTORequest);
            return Ok(ApiResponse<List<UnitDTOResponse>>.SuccesWithData(unitDetails));
        }
		[Authorize(Roles = "Admin,Müdür,Çalışan")]
		[HttpPost("/Unit")]
        public async Task<IActionResult> GetAsync(UnitDTORequest unitDTORequest)
        {
            var unit = await _unitService.GetAsync(unitDTORequest);
            return Ok(ApiResponse<UnitDTOResponse>.SuccesWithData(unit));
        }
		[Authorize(Roles = "Admin")]
		[HttpPost("/AddUnit")]
        [ValidationFilter(typeof(UnitValidation))]
        public async Task<IActionResult> AddAsync(UnitDTORequest unitDTORequest)
        {
            var addedUnit = await _unitService.AddAsync(unitDTORequest);
            return Ok(ApiResponse<UnitDTOResponse>.SuccesWithData(addedUnit));
        }
		[Authorize(Roles = "Admin")]
		[HttpPost("/UpdateUnit")]
        [ValidationFilter(typeof(UnitValidation))]
        public async Task<IActionResult> UpdateAsync(UnitDTORequest unitDTORequest)
        {
            await _unitService.UpdateAsync(unitDTORequest);
            return Ok(ApiResponse<UnitDTOResponse>.SuccesWithOutData());
        }
		[Authorize(Roles = "Admin")]
		[HttpPost("/DeleteUnit")]
        public async Task<IActionResult> DeleteAsync(UnitDTORequest unitDTORequest)
        {
            await _unitService.DeleteAsync(unitDTORequest);
            return Ok(ApiResponse<UnitDTOResponse>.SuccesWithOutData());
        }
    }
}
