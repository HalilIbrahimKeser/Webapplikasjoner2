using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oblig2_Blogg.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Oblig2_Blogg.Models;

namespace Oblig2_Blogg.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository repository;
        private UserManager<IdentityUser> manager;

        public BlogController(IBlogRepository repository)
        {
            this.repository = repository;
            this.manager = manager;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        // GET
        // Blog/Create
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST
        // Blog/Create
        [AllowAnonymous]
        [HttpPost] 
        public ActionResult Create([Bind("Name,Description,Created, Closed, Owner")] Blog blog) 
        { 
            try 
            { 
                repository.Save(blog);
                return RedirectToAction("Index");
            } 
            catch 
            { 
                return View();
            }

        }
    }
}
