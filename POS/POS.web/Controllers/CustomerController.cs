using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerService _service;

        public CustomerController(ApplicationContext context)
        {
            _service= new CustomerService(context);
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var data = _service.GetCustomers();
            return View(data);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var dataDetail = _service.GetCustomersById(id);
            return View(dataDetail);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult Save([Bind("CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax")] CustomerModel request)
        {
            if (ModelState.IsValid)
            {
                _service.SaveCustomer(new CustomersEntity(request));
                return Redirect("GetAll");
            }
            return View("Add", request);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var entity = _service.GetCustomersById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(CustomersEntity request)
        {
            _service.UpdateCustomer(request);
            return Redirect("GetAll");
        }

        [HttpGet]
        public IActionResult Delete(int? id) 
        {
            _service.DeleteCustomer(id);
            return Redirect("Customer/GetAll");
        }
        
    }
}
