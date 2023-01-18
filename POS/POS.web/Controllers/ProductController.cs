using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _service;
        private readonly CategoryService _categoryService;
        private readonly SupplierService _supplierService;

        public ProductController(ApplicationContext context)
        {
            _service = new ProductService(context);
            _categoryService = new CategoryService(context);
            _supplierService = new SupplierService(context);
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
            ViewBag.Categories = new SelectList(_categoryService.GetCategories(), "Id", "CategoryName");
            ViewBag.Suppliers = new SelectList(_supplierService.GetSuppliers(), "Id", "CompanyName");
            return View();
        }

        [HttpGet]
        public IActionResult AddModal() 
        {
            ViewBag.Categories = new SelectList(_categoryService.GetCategories(), "Id", "CategoryName");
            ViewBag.Suppliers = new SelectList(_supplierService.GetSuppliers(), "Id", "CompanyName");
            return PartialView("_Add");
        }

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
            ViewBag.Categories = new SelectList(_categoryService.GetCategories(), "Id", "CategoryName");
            ViewBag.Suppliers = new SelectList(_supplierService.GetSuppliers(), "Id", "CompanyName");
            var entity = _service.GetProductById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("Id, ProductName, SupplierId, CategoryId, Quantity_per_unit, UnitPrice, UnitsInStoct, UnitsOnOrder, ReorderLevel, Discontinued")] ProductModel request)
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
