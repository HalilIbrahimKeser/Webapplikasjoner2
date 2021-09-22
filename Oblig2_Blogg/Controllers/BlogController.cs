using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oblig2_Blogg.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Oblig2_Blogg.Models.Repository;

namespace Oblig2_Blogg.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly IRepository repository;
        //private UserManager<IdentityUser> manager;

        public BlogController(IRepository repository)
        {
            this.repository = repository;
            //this.manager = manager;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        // GET
        // Blog/Create
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST
        // Blog/Create
        [Authorize]
        [HttpPost] 
        public ActionResult Create([Bind("Name, Description, Created, Closed, Owner")] Blog blog) 
        { 
            try 
            {
                if (ModelState.IsValid)
                {
                    var owner = User;
                    
                    repository.Save(blog, owner);
                    //TempData["message"] = string.Format("{0} har blitt opprettet", blog.Name);
                    return RedirectToAction(nameof(Index));
                }
                return View(blog);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
