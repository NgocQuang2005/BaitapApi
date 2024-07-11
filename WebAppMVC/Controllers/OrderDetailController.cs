using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebAppMVC.Controllers
{
    public class OrderDetailController : Controller
    {
        // GET: OrderDetailController
        private readonly IOrderDetailService _orderDetailService;
        public OrderDetailController(IOrderDetailService orderdetailService)
        {
            _orderDetailService = orderdetailService;
        }
        public async Task<ActionResult> Index()
        {
            var orderDetail = await _orderDetailService.GetAllOrderDetail();
            return View(orderDetail);
        }

        // GET: OrderController/Details/5
        public async Task<ActionResult> Details(int OrderId)
        {
            var orderDetail = await _orderDetailService.GetOrderDetailByOrderId(OrderId);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return View(orderDetail);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                await _orderDetailService.Create(orderDetail);
                return RedirectToAction(nameof(Index));
            }
            return View(orderDetail);
        }

        // GET: OrderController/Edit/5
        public async Task<ActionResult> Edit(int OrderId)
        {
            var orderDetail = await _orderDetailService.GetOrderDetailByOrderId(OrderId);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return View(orderDetail);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int OrderId, int  ProductId, OrderDetail orderDetail)
        {
            if (OrderId != orderDetail.OrderId)
            {
                return NotFound();
            }
            if (ProductId != orderDetail.ProductId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _orderDetailService.Update(orderDetail);
                return RedirectToAction(nameof(Index));
            }
            return View(orderDetail);
        }

        // GET: OrderController/Delete/5
        public async Task<ActionResult> Delete(int OrderId)
        {
            var orderDetail = await _orderDetailService.GetOrderDetailByOrderId(OrderId);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return View(orderDetail);

        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int OrderId, OrderDetail orderDetail)
        {
            try
            {
                await _orderDetailService.GetOrderDetailByOrderId(OrderId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(orderDetail);
            }
        }
    }
}
