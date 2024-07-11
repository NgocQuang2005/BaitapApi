using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _OrderRepository;
        public OrderController()
        {
            _OrderRepository = new OrderRepository();
        }
        // GET: api/<OrderController>
        [HttpGet]
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _OrderRepository.GetAllOrder();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var Order = await _OrderRepository.GetOrderById(id);
            if (Order == null)
            {
                return NotFound();
            }
            return Order;
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult> Post(Order Order)
        {
            await _OrderRepository.Add(Order);
            return Content("Insert Success");
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Order Order)
        {
            var temp = await _OrderRepository.GetOrderById(id);
            if (temp == null)
            {
                return NoContent();
            }
            await _OrderRepository.Update(Order);
            return Content("Update Success");
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            var temp = await _OrderRepository.GetOrderById(id);
            if (temp == null)
            {
                return NoContent();
            }
            await _OrderRepository.Delete(id);
            return Content("Delete Success");
        }
    }
}
