using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _service;

        public EmployeeController(ApplicationContext context)
        {
                _service = new EmployeeService(context);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _service.GetEmployees();
            return View(data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddModal()
        {
            return PartialView("_Add");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save([Bind("LastName, FirstName, Title,  TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath")] EmployeeModel request)
        {

            if (ModelState.IsValid)
            {
                _service.SaveEmployee(new EmployeesEntity(request));
                return Redirect("GetAll");
            }
            return View("Add", request);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var entity = _service.GetEmployeeById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("Id, LastName, FirstName, Title,  TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath")] EmployeeModel request)
        {
            _service.UpdateEmployee(request);
            return Redirect("GetAll");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            _service.DeleteEmployee(id);
            return Redirect("/Employee/GetAll");
        }
    }
}
