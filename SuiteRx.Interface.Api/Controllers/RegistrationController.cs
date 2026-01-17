using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuiteRx.Interface.Application.Dto;
using SuiteRx.Interface.Application.Services;
using SuiteRx.Interface.Application.Services.Impl;

namespace SuiteRx.Interface.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {

        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService
            )
        {
            _registrationService = registrationService;
        }

        [HttpPost("Save")]
        public async Task<ActionResult> Create(RegistrationDto request)
        {
            await _registrationService.SaveRegistrationAsync(request);
            return Created(string.Empty, request);
        }



        [HttpPost("GetAllRegistration")]
        public async Task<ActionResult> GetAllRegistration()
        {
            var data = await _registrationService.GetAllRegistration();
            return Ok(data);
        }
    }
}
