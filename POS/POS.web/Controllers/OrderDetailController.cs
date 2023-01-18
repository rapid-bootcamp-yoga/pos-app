using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Repository;
using POS.Service;
using POS.ViewModel;
using System.Reflection.Metadata;

namespace POS.web.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly OrderDetailService _service;
        private readonly OrderService _orderService;
        private readonly ProductService _productService;

        public OrderDetailController(ApplicationContext context)
        {
            _service = new OrderDetailService(context);
            _orderService = new OrderService(context);
            _productService= new ProductService(context);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _service.GetOrderDetails();
            return View(data);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var dataDetail = _service.GetOrderDetailById(id);
            return View(dataDetail);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Order = new SelectList(_orderService.GetOrders(), "Id", "Id");
            ViewBag.Product = new SelectList(_productService.GetProducts(), "Id", "ProductName");
            return View();
        }

        [HttpGet]
        public IActionResult AddModal()
        {
            ViewBag.Order = new SelectList(_orderService.GetOrders(), "Id", "Id");
            ViewBag.Product = new SelectList(_productService.GetProducts(), "Id", "ProductName");
            return View("_Add");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save([Bind("Id, OrderId, ProductId, UnitPrice, Quantity, Discount")]OrderDetailModel request)
        {
            if (ModelState.IsValid)
            {
                _service.SaveOrderDetail(new OrderDetailsEntity(request));
                return Redirect("GetAll");
            }
            return View("Add", request);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var entity = _service.GetOrderDetailById(id);
            return View(entity);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            _service.DeleteOrderDetail(id);
            return Redirect("/OrderDetail/GetAll");
        }
    }
}
