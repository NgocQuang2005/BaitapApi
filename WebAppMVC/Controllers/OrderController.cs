using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebAppMVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<ActionResult> Index()
        {
            var order = await _orderService.GetOrders();
            return View(order);
        }

        // GET: OrderController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var order = await _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Order order)
        {
            if (ModelState.IsValid)
            {
                await _orderService.Create(order);
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: OrderController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var order = await _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _orderService.Update(order);
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: OrderController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var order = await _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);

        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Order order)
        {
            try
            {
                await _orderService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(order);
            }
        }
    }
}
