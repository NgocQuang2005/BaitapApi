using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebAppMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService ProductService)
        {
            _productService = ProductService;
        }
        public async Task<ActionResult> Index()
        {
            var Product = await _productService.GetProducts();
            return View(Product);
        }

        // GET: ProductController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.Create(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: ProductController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _productService.Update(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: ProductController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);

        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Product product)
        {
            try
            {
                await _productService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(product);
            }
        }
    }
}
