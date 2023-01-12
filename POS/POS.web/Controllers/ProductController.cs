using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _service;

        public ProductController(ApplicationContext context)
        {
            _service = new ProductService(context);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var data = _service.GetProducts();
            return View(data);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var dataDetail = _service.GetProductById(id);
            return View(dataDetail);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Save([Bind("CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax, HomePage")] ProductModel request)
        //{
        //    return View();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save([Bind("ProductName, SupplierId, CategoryId, Quantity_per_unit, UnitPrice, UnitsInStoct, UnitsOnOrder, ReorderLevel, Discontinued")] ProductModel request)
        {
            if (ModelState.IsValid)
            {
                _service.SaveProduct(new ProductsEntity(request));
                return Redirect("GetAll");
            }
            return View("Add", request);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var entity = _service.GetProductById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("Id, ProductName, SupplierId, CategoryId, Quantity_per_unit, UnitPrice, UnitsInStoct, UnitsOnOrder, ReorderLevel, Discontinued")] ProductsEntity request)
        {
            _service.UpdateProduct(request);
            return Redirect("GetAll");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            _service.DeleteProduct(id);
            return Redirect("/Product/GetAll");
        }
    }
}
