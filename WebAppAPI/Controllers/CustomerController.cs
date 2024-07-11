using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _CustomerRepository;
        public CustomerController()
        {
            _CustomerRepository = new CustomerRepository();
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _CustomerRepository.GetAllCustomer();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var Customer = await _CustomerRepository.GetCustomerById(id);
            if (Customer == null)
            {
                return NotFound();
            }
            return Customer;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<ActionResult> Post(Customer Customer)
        {
            await _CustomerRepository.Add(Customer);
            return Content("Insert Success");
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Customer Customer)
        {
            var temp = await _CustomerRepository.GetCustomerById(id);
            if (temp == null)
            {
                return NoContent();
            }
            await _CustomerRepository.Update(Customer);
            return Content("Update Success");
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            var temp = await _CustomerRepository.GetCustomerById(id);
            if (temp == null)
            {
                return NoContent();
            }
            await _CustomerRepository.Delete(id);
            return Content("Delete Success");
        }
    }
}
