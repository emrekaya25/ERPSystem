using ERPSystem.Business.Abstract;
using ERPSystem.Business.Utilities.Attributes;
using ERPSystem.Business.Utilities.Validation.UnitValidator;
using ERPSystem.Business.Utilities.Validation.UserValidator;
using ERPSystem.Entity.DTO.UnitDTO;
using ERPSystem.Entity.DTO.UserDTO;
using ERPSystem.Entity.Entities;
using ERPSystem.Entity.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Admin,Müdür")]
        [HttpPost("/Users")]
        public async Task<IActionResult> GetAllAsync(UserDTORequest userDTORequest)
        {
            var users = await _userService.GetAllAsync(userDTORequest);
            return Ok(ApiResponse<List<UserDTOResponse>>.SuccesWithData(users));
        }
        [Authorize(Roles = "Admin,Müdür,Çalışan")]
        [HttpPost("/User")]
        public async Task<IActionResult> GetAsync(UserDTORequest userDTORequest)
        {
            var user = await _userService.GetAsync(userDTORequest);
            return Ok(ApiResponse<UserDTOResponse>.SuccesWithData(user));
        }

        [Authorize(Roles = "Admin,Müdür")]
        [HttpPost("/AddUser")]
        [ValidationFilter(typeof(UserValidation))]
        public async Task<IActionResult> AddAsync(UserDTORequest userDTORequest)
        {
            var addedUser = await _userService.AddAsync(userDTORequest);
            return Ok(ApiResponse<UserDTOResponse>.SuccesWithData(addedUser));
        }

        [Authorize(Roles = "Admin,Müdür")]
        [HttpPost("/UpdateUser")]
        [ValidationFilter(typeof(UserValidation))]
        public async Task<IActionResult> UpdateAsync(UserDTORequest userDTORequest)
        {
            await _userService.UpdateAsync(userDTORequest);
            return Ok(ApiResponse<UserDTOResponse>.SuccesWithOutData());
        }

        [Authorize(Roles = "Admin,Müdür")]
        [HttpPost("/DeleteUser")]
        public async Task<IActionResult> DeleteAsync(UserDTORequest userDTORequest)
        {
            await _userService.DeleteAsync(userDTORequest);
            return Ok(ApiResponse<UserDTOResponse>.SuccesWithOutData());
        }
    }
}
