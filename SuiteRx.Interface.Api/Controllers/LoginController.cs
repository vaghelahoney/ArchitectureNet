using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuiteRx.Interface.Application.Dto;
using SuiteRx.Interface.Application.Services;

namespace SuiteRx.Interface.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IAuthService _authService;   

        public LoginController(IAuthService authService)
        {
            _authService = authService;

        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto )
        {
            if (loginRequestDto == null) return BadRequest("Invalid request");

            var data = await _authService.LoginAsync(loginRequestDto);

            if (data == null) return Unauthorized(new { message = "Invalid credentials" });

            return Ok(data);
        }
    }
}
