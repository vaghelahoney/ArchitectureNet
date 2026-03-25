using Microsoft.AspNetCore.Mvc;
using SuiteRx.Interface.Application.Dto;
using SuiteRx.Interface.Application.Services;

namespace SuiteRx.Interface.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost("Save")]
        public async Task<ActionResult> Create(DepartmentDto request)
        {
            await _departmentService.SaveDepartmentAsync(request);
            return Created(string.Empty, request);
        }

        [HttpGet("GetAllDepartments")]
        public async Task<ActionResult> GetAllDepartments()
        {
            var data = await _departmentService.GetAllDepartmentsAsync();
            return Ok(data);
        }

        [HttpGet("GetDepartmentByIdAsync/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var data = await _departmentService.GetDepartmentByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update(DepartmentDto request)
        {
            var success = await _departmentService.UpdateDepartmentAsync(request);
            if (!success)
            {
                return NotFound();
            }
            return Ok(request);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _departmentService.DeleteDepartmentAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
