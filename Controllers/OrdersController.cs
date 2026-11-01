using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolidPrincipaleDemo.Models;
using SolidPrincipaleDemo.Services;

namespace SolidPrincipaleDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_orderService.GetAllOrders());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var order = _orderService.GetOrderById(id);

            if (order is null)
            {
                return NotFound(new
                {
                    Message = "Order not found."
                });
            }

            return Ok(order);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderRequest request)
        {
            try
            {
                var order = _orderService.CreateOrder(request);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = order.Id },
                    order);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    Message = ex.Message
                });
            }
        }
    }

}
