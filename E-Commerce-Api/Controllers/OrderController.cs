using E_Commerce_Api.Domain;
using E_Commerce_Api.Interface;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Api.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            try
            {
                var createdOrder = await _orderService.CreateOrderAsync(order);
                return CreatedAtAction(nameof(order), new { orderId = createdOrder.Id }, createdOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetOrdersByUser(Guid userId)
        {
            var orders = await _orderService.GetOrdersByUserIdAsync(userId);
            if (orders == null || orders.Count == 0)
                return NotFound(new { message = "Sipariş bulunamadı." });

            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById(Guid orderId)
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);
            if (order == null)
                return NotFound(new { message = "Sipariş bulunamadı." });

            return Ok(order);
        }


        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteOrder(Guid orderId)
        {
            var deleted = await _orderService.DeleteOrderAsync(orderId);
            if (!deleted)
                return NotFound(new { message = "Sipariş bulunamadı veya silinemedi." });

            return NoContent();
        }
    }
}
