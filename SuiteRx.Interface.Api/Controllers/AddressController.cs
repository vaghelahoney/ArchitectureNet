using Microsoft.AspNetCore.Mvc;
using SuiteRx.Interface.Application.Dto;
using SuiteRx.Interface.Application.Services;

namespace SuiteRx.Interface.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost("Save")]
        public async Task<ActionResult> Create(AddressDto request)
        {
            await _addressService.SaveAddressAsync(request);
            return Created(string.Empty, request);
        }

        [HttpGet("GetAllAddresses")]
        public async Task<ActionResult> GetAllAddresses()
        {
            var data = await _addressService.GetAllAddressesAsync();
            return Ok(data);
        }

        [HttpGet("GetAddressByIdAsync/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var data = await _addressService.GetAddressByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update(AddressDto request)
        {
            var success = await _addressService.UpdateAddressAsync(request);
            if (!success)
            {
                return NotFound();
            }
            return Ok(request);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _addressService.DeleteAddressAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
