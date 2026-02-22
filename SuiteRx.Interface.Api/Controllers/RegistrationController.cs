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

            var name = "Prakash";
            var submane = "prakash";

            if (string.Equals(name,submane, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("same");
            }

            var profileTask = _registrationService.GetAllRegistration();
            var ordersTask = GetOrdersAsync();

            await Task.WhenAll(profileTask, ordersTask);

            var data = await profileTask;
            
            if (data == null || !data.Any())
            {
                return NotFound("No registrations found.");
            }
            return Ok(data);
        }

        private async Task<List<string>> GetOrdersAsync()
        {
            // Simulating an async operation
            await Task.Delay(10); 
            return new List<string> { "Order1", "Order2" };
        }
    }
}
