using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SolidPrincipaleDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateOrder()
        {
            // Validate order
            Console.WriteLine("Validating order...");

            // Calculate price
            decimal total = 1000;

            // Save order
            Console.WriteLine("Saving order...");

            // Process payment
            Console.WriteLine("Processing payment...");

            // Send email
            Console.WriteLine("Sending email...");

            return Ok(new
            {
                Message = "Order created successfully",
                Total = total
            });
        }
    }
}
