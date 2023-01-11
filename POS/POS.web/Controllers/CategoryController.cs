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
    }
}
