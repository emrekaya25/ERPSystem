using AutoMapper;
using ERPSystem.Business.Abstract;
using ERPSystem.DataAccess.Abstract.DataManagement;
using ERPSystem.Entity.DTO.LoginDTO;
using ERPSystem.Entity.DTO.UserDTO;
using ERPSystem.Entity.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ERPSystem.API.Controllers
{
    [AllowAnonymous()]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly IUserRoleService _userRoleService;


        public LoginController(IConfiguration configuration, IUserService userService, IUserRoleService userRoleService)
        {
            _configuration = configuration;
            _userService = userService;
            _userRoleService = userRoleService;
        }

        [HttpPost("/LoginAsync")]
        public async Task<IActionResult> LoginAsync(LoginDTORequest loginDTORequest)
        {
            var user = await _userService.LoginAsync(loginDTORequest);

            if (user == null)
            {
                return Ok(ApiResponse<LoginDTOResponse>.SuccesNoDataFound("Kullanıcı Adı veya Şifre Hatalı, Tekrar Deneyiniz!"));
            }


            else
            {
                List<Claim> claims = new List<Claim>()
                {
                new Claim(ClaimTypes.Name , user.Name),
                new Claim(ClaimTypes.Email , user.Email),
                };

                foreach (var item in user.RoleName)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item));
                }

                var secretKey = _configuration["JWT:Token"];
                var issuer = _configuration["JWT:Issuer"];
                var audiance = _configuration["JWT:Audiance"];


                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(secretKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Audience = audiance,
                    Issuer = issuer,
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(20), // Token süresi (örn: 20 dakika)
                    NotBefore= DateTime.Now,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                user.Token = tokenHandler.WriteToken(token);

                return Ok(ApiResponse<LoginDTOResponse>.SuccesWithData(user));
            }


            
        }
    }
}
