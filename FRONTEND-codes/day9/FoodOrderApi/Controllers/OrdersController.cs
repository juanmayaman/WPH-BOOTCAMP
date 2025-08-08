using FoodOrderApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FoodOrderApi.Models;

namespace FoodOrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DataStore _store;
        public OrdersController(DataStore store)
        {
            _store = store;
        }

        [HttpPost]

        public ActionResult<Order> PlaceOrder(Order order)
        {
            order.Id = _store.Orders.Count + 1;
            _store.Orders.Add(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        [HttpGet]

        public ActionResult<IEnumerable<Order>> GetAllOrders()
        {
            return Ok(_store.Orders);
        }

        [HttpGet("{id}")]

        public ActionResult<Order> GetOrder(int id)
        {
            var order = _store.Orders.FirstOrDefault(o => o.Id == id);
            return order == null ? NotFound() : Ok(order);
        }

        [HttpPut("{id}")]

        public IActionResult UpdateOrder(int id,Order updatedOrder)
        {
            var order = _store.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null) return NotFound();

            order.CustomerName = updatedOrder.CustomerName;
            order.FoodItemIds = updatedOrder.FoodItemIds;
            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteOrder (int id)
        {
            var order = _store.Orders.FirstOrDefault(o => o.Id == id);
            if(order == null) return NotFound();

            _store.Orders.Remove(order);
            return NoContent();
        }
    }
}
