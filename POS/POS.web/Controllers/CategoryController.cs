using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;

namespace POS.web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _service;

        public CategoryController(ApplicationContext context)
        {
            _service = new CategoryService(context);
        }
        public IActionResult GetAll()
        {
            var Data = _service.GetCategories();
            return View(Data);
        }

        public IActionResult Details(int? id) 
        {
            var DataDetail = _service.GetCategoriesById(id);
            return View(DataDetail);
        }

        public IActionResult Add()
        {
            return View();
        }
        
        public IActionResult Save([Bind("CategoryName, Description, Picture")] CategoriesEntity request)
        {
            _service.SaveCategory(request);
            return Redirect("GetAll");
        }

        public IActionResult Edit(int? id)
        {
            var entity = _service.GetCategoriesById(id);
            return View(entity);
        }
        
        public IActionResult Update([Bind("CategoryName, Description, Picture")] CategoriesEntity request)
        {
            _service.UpdateCategories(request);
            return View("GetAll");
        }

        public IActionResult Delete(int? id)
        {
            _service.DeleteById(id);
            return View("GetAll");
        }
    }
}
