using Microsoft.AspNetCore.Mvc;
using SuiteRx.Interface.Application.Dto;
using SuiteRx.Interface.Application.Services;

namespace SuiteRx.Interface.Api.Controllers
{
    [Route("v1/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        private readonly IAuthService _iuthService;

        

        public OrdersController(IOrderService orderService, IAuthService iuthService)
        {
            _orderService = orderService;
            _iuthService = iuthService;
        }

        [HttpPost("refill")]
        public async Task<ActionResult> Create(HL7MessageDto request)
        {
            await _orderService.Refill(request);
            return Created(string.Empty, request);
        }
       
        [HttpPost("LoginAsync")]
        public async Task<ActionResult> LoginAsync(LoginRequestDto request)
        {
            var token = await _iuthService.LoginAsync(request);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("❌ Invalid email or password");
            }

            return Ok(new
            {
                token,
                message = "✅ Login successful"
            });
        }


    }
}
