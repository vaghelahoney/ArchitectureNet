using Microsoft.AspNetCore.Mvc;
using SuiteRx.Interface.Application.Dto;
using SuiteRx.Interface.Application.Services;

namespace SuiteRx.Interface.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothesController : ControllerBase
    {
        private readonly IClothesService _clothesService;

        public ClothesController(IClothesService clothesService)
        {
            _clothesService = clothesService;
        }

        [HttpPost("Save")]
        public async Task<ActionResult> Create(ClothesDto request)
        {
            await _clothesService.SaveClothesAsync(request);
            return Created(string.Empty, request);
        }

        [HttpGet("GetAllClothes")]

        public async Task<ActionResult> GetAllClothes()
        {
            var data = await _clothesService.GetAllClothesAsync();
            return Ok(data);
        }

        [HttpGet("GetClothesByIdAsync/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var data = await _clothesService.GetClothesByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update(ClothesDto request)
        {
            var success = await _clothesService.UpdateClothesAsync(request);
            if (!success)
            {
                return NotFound();
            }
            return Ok(request);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _clothesService.DeleteClothesAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
