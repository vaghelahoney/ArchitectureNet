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
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto )
        {
           var data= await _authService.LoginAsync(loginRequestDto);
            return Ok(data);
        }
    }
}
