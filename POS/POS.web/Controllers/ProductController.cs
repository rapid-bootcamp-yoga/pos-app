using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;

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
    }
}
