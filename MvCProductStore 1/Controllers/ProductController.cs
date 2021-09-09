using Microsoft.AspNetCore.Mvc;
using MvCProductStore_1.Models.Entities;
using MvCProductStore_1.Models.Repository;
using MvCProductStore_1.Models.ViewModels;

namespace MvCProductStore_1.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository repository;

        public ProductController(IRepository repository) => this.repository = repository;

        public IActionResult Index()
        {
            return base.View(repository.GetAll());
        }

        /*
        public ViewResult About()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Contact()
        {
            return View();
        

        [HttpPost]
        public ViewResult Contact(Contact response)
        {
            repository.AddResponse(response);
            return View("Thank you", response);
        }}
        */

        //GET
        [HttpGet]
        public ActionResult Create()
        {
            var product = repository.GetProductEditViewModel();
            return View(product);
        }

        //POST
        [HttpPost]
        public ActionResult Create(
            [Bind("Name,Description,Price,ManufacturerId,CategoryId")] ProductEditViewModel product)
        {
            if (ModelState.IsValid)
            {
                repository.Save(product);
                TempData["message"] = string.Format("{0} har blitt opprettet", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

    }
}
