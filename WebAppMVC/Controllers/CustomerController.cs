using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebAppMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<ActionResult> Index()
        {
            var customer = await _customerService.GetCustomers();
            return View(customer);
        }

        // GET: CustomerController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _customerService.Create(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: CustomerController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _customerService.Update(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: CustomerController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);

        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Customer customer)
        {
            try
            {
                await _customerService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(customer);
            }
        }
    }
}
