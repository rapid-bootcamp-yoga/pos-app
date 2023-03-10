using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _service;

      
        public CategoryController(ApplicationContext context)
        {
            _service = new CategoryService(context);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _service.GetCategories();
            return View(data);
        }

        [HttpGet]
        public IActionResult Details(int? id) 
        {
            var dataDetail = _service.GetCategoriesById(id);
            return View(dataDetail);
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
        public IActionResult Save([Bind("CategoryName, Description, Picture")] CategoryModel request)
        {

            if (ModelState.IsValid)
            {
                _service.SaveCategory(new CategoriesEntity(request));
                return Redirect("GetAll");
            }
            return View("Add", request);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var model = _service.GetCategoriesById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("Id, CategoryName, Description, Picture")] CategoryModel request)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateCategories(request);
                return Redirect("GetAll");
           }
            return View("Edit", request);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Update([Bind("Id, CategoryName, Description, Picture")] CategoriesEntity request)
        //{
        //        _service.UpdateCategories(request);
        //        return Redirect("GetAll");
        //}


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            _service.DeleteCategory(id);
            return Redirect("/Category/GetAll");
        }
    }
}
 