using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        // GET: api/<OrderDetailDetailController>
        private readonly IOrderDetailRepository _OrderDetailRepository;
        public OrderDetailController()
        {
            _OrderDetailRepository = new OrderDetailRepository();
        }
        // GET: api/<OrderDetailController>
        [HttpGet]
        public async Task<IEnumerable<OrderDetail>> GetOrderDetails()
        {
            return await _OrderDetailRepository.GetAllOrderDetail();
        }

        // GET api/<OrderDetailController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetail(int id)
        {
            var OrderDetails = await _OrderDetailRepository.GetOrderDetailByOrderId(id);
            if (OrderDetails == null)
            {
                return NotFound();
            }
            return Ok(OrderDetails);
        }

        // POST api/<OrderDetailController>
        [HttpPost]
        public async Task<ActionResult> Post(OrderDetail OrderDetail)
        {
            await _OrderDetailRepository.Add(OrderDetail);
            return Content("Insert Success");
        }

        // PUT api/<OrderDetailController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int OrderId, int ProductId, OrderDetail OrderDetail)
        {
            var temp = await _OrderDetailRepository.GetOrderDetailByOrderIdProductId(OrderId,ProductId);
            if (temp == null)
            {
                return NoContent();
            }
            OrderDetail.OrderId = OrderId;
            OrderDetail.ProductId = ProductId;
            await _OrderDetailRepository.Update(OrderDetail);
            return Content("Update Success");
        }

        //DELETE api/<OrderDetailController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int OrderId, int ProductId)
        {

            var temp = await _OrderDetailRepository.GetOrderDetailByOrderIdProductId(OrderId, ProductId);
            if (temp == null)
            {
                return NoContent();
            }
            await _OrderDetailRepository.Delete(OrderId,ProductId);
            return Content("Delete Success");
        }
    }

}
