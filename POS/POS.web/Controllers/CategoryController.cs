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

        [HttpPost]
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
            var entity = _service.GetCategoriesById(id);
            return View(entity);
        }

        //[HttpPost]
        //public IActionResult Update([Bind("Id, CategoryName, Description, Picture")] CategoryModel request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        CategoriesEntity categoriesEntity = new CategoriesEntity(request);
        //        categoriesEntity.CategoryId = request.CategoryId;
        //        _service.UpdateCategories(categoriesEntity);
        //        return Redirect("GetAll");
        //    }
        //    return View("Edit", request);
        //}

        [HttpPost]
        public IActionResult Update([Bind("Id, CategoryName, Description, Picture")] CategoriesEntity request)
        {
                _service.UpdateCategories(request);
                return Redirect("GetAll");
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            _service.DeleteCategory(id);
            return Redirect("/Category/GetAll");
        }
    }
}
