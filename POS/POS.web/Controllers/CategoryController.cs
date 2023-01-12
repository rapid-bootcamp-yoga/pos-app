using Microsoft.AspNetCore.Mvc;
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
            var Data = _service.GetCategories();
            return View(Data);
        }

        [HttpGet]
        public IActionResult Details(int? id) 
        {
            var DataDetail = _service.GetCategoriesById(id);
            return View(DataDetail);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save([Bind("CategoryName, Description, Picture")] CategoryModel request)
        {
            //_service.SaveCategory(request);
            //return Redirect("GetAll");

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

        [HttpPost]
        public IActionResult Update([Bind("CategoryId, CategoryName, Description, Picture")] CategoryModel request)
        {
            CategoriesEntity categoriesEntity = new CategoriesEntity(request);
            categoriesEntity.CategoryId = request.CategoryId;
            _service.UpdateCategories(categoriesEntity);
            return Redirect("GetAll");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            _service.DeleteById(id);
            return Redirect("GetAll");
        }
    }
}
