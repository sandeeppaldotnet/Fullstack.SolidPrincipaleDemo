using Microsoft.AspNetCore.Mvc;
using SolidPrincipaleDemo.Models;
using SolidPrincipaleDemo.Services;

namespace SolidPrincipaleDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentsController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public IActionResult ProcessPayment(PaymentRequest request)
        {
            var result = _paymentService.ProcessPayment(
                request.PaymentMethod,
                request.Amount);

            if (!result.IsSuccessful)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }

}
