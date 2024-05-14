using Microsoft.AspNetCore.Mvc;
using Saxmay.Business.Interfaces;
using Saxmay.Entities.Dtos;

namespace Saxmay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthBusiness _authBusiness;

        public AuthController(IAuthBusiness authBusiness)
        {
            _authBusiness = authBusiness;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationDto dto)
        {
            var result = await _authBusiness.Register(dto);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var result = await _authBusiness.Login(login);
            return Ok(result);
        }

        [HttpPost("assignRole")]
        public async Task<IActionResult> AssignRole(RegistrationDto dto)
        {
            var result = await _authBusiness.AssingRole(dto.Email, dto.Role);
            return Ok(result);
        }
    }
}
