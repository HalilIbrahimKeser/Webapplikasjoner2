using System;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvCProductStore_1.Models.Entities;
using MvCProductStore_1.Models.Repository;
using MvCProductStore_1.Models.ViewModels;

namespace MvCProductStore_1.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository repository;
        private UserManager<IdentityUser> manager;

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
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            var product = repository.GetProductEditViewModel();
            return View(product);
        }

        //POST
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create(
            [Bind("Name,Description,Price, modified, ManufacturerId,CategoryId, Owner")] ProductEditViewModel product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var owner = manager.FindByNameAsync(principal.Identity.Name);
                    var productToSave = new ProductEditViewModel();
                    productToSave.Name = product.Name;
                    productToSave.CategoryId = product.CategoryId;
                    productToSave.Price = product.Price;
                    productToSave.Description = product.Description;
                    productToSave.ManufacturerId = product.ManufacturerId;
                    //productToSave.Owner = owner.Result;

                    repository.Save(productToSave, User);
                    //TempData["message"] = string.Format("{0} har blitt opprettet", product.Name);
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return RedirectToAction(nameof(Index));
            }
        }

    }
}
