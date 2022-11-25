using Karavan.Data;
using Karavan.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KaravanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _Order;
        public OrderController(IOrder Order)
        {
            _Order = Order;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            IQueryable<Order> model = _Order.GetOrders;
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrder([FromBody] Order _order)
        {
            if (_order == null)
            {
                return BadRequest();
            }
            POJO model = await _Order.PlaceOrder(_order);
            if (model == null)
            {
               return NotFound();
            }
            return Ok(model);
        }
        /*
        [HttpGet ("{id}/{password}")]
        public async Task<IActionResult> Login(string? phoneNumber, string? password)
        {
            if (phoneNumber == null || password == null)
            {
                return BadRequest();
            }
            Person model = await _Person.GetPerson(phoneNumber, password);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            POJO model = await _Person.DeleteUser(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok();
        }
        */
    }
}
