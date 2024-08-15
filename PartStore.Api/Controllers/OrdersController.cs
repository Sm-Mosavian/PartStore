using Microsoft.AspNetCore.Mvc;
using PartsStoreAPI.Core.Interfaces;
using PartStore.Domain.Entities;

namespace PartStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PlaceOrder(Order order)
        {
            var placedOrder = await _orderService.PlaceOrderAsync(order);
            return CreatedAtAction(nameof(PlaceOrder), new { id = placedOrder.Id }, placedOrder);
        }
    }
}
