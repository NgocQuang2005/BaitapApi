using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController()
        {
            _productRepository = new ProductRepository();
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productRepository.GetAllProduct();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var Product = await _productRepository.GetProductById(id);
            if (Product == null)
            {
                return NotFound();
            }
            return Product;
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult> Post(Product Product)
        {
            await _productRepository.Add(Product);
            return Content("Insert Success");
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Product Product)
        {
            var temp = await _productRepository.GetProductById(id);
            if (temp == null)
            {
                return NoContent();
            }
            await _productRepository.Update(Product);
            return Content("Update Success");
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            var temp = await _productRepository.GetProductById(id);
            if (temp == null)
            {
                return NoContent();
            }
            await _productRepository.Delete(id);
            return Content("Delete Success");
        }
    }
}
