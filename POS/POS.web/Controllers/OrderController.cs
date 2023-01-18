using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.web.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService _service;
        private readonly CustomerService _customerService;
        private readonly EmployeeService _employeeService;

        public OrderController(ApplicationContext context)
        {
            _service = new OrderService(context);
            _customerService = new CustomerService(context);
            _employeeService = new EmployeeService(context);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data =_service.GetOrders();
            return View(data);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var dataDetail = _service.GetOrderById(id);
            return View(dataDetail);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Customer = new SelectList(_customerService.GetCustomers(), "Id", "CompanyName");
            ViewBag.Employee = new SelectList(_employeeService.GetEmployees(), "Id", "FirstName");
            return View();
        }

        [HttpGet]
        public IActionResult AddModal()
        {
            ViewBag.Customer = new SelectList(_customerService.GetCustomers(), "Id", "CompanyName");
            ViewBag.Employee = new SelectList(_employeeService.GetEmployees(), "Id", "FirstName");
            return View("_Add");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save([Bind("CustomerId, EmployeesId, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry")]OrderModel request)
        {
            if (ModelState.IsValid)
            {
                _service.SaveOrder(new OrdersEntity(request));
                return Redirect("GetAll");
            }
            return View("Add", request);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ViewBag.Customer = new SelectList(_customerService.GetCustomers(), "Id", "CompanyName");
            ViewBag.Employee = new SelectList(_employeeService.GetEmployees(), "Id", "FirstName");
            var entity = _service.GetOrderById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("Id, CustomerId, EmployeesId, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry")] OrderModel request)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateOrder(request);
                return Redirect("GetAll");
            }
            return View("Edit", request);
            
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            _service.DeleteOrder(id);
            return Redirect("/Order/GetAll");
        }
    }
}
