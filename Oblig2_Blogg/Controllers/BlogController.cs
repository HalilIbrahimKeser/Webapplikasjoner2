using System;
using System.Linq;
using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oblig2_Blogg.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Oblig2_Blogg.Models.Repository;
using Oblig2_Blogg.Models.ViewModels;

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
            return View(repository.GetAllBlogs());
        }

        [AllowAnonymous]
        public ActionResult ReadBlog(int id)
        {
            var blog = repository.GetBlog(id);
            var posts = repository.GetAllPosts(id);

            var viewModel = new BlogViewModel()
            {
                BlogId = id, Name = blog.Name, Posts = posts.ToList()
            };
            

            return View(viewModel);
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
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name, Description, Created, Closed, Owner")] Blog blog) 
        { 
            try 
            {
                if (ModelState.IsValid)
                {
                    var owner = User;
                    
                    repository.SaveBlog(blog, owner);
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

        // GET:
        // BlogController/Edit/5
        public ActionResult Edit(int id)
        {
            var blogToEdit = repository.GetBlog(id);
            
            return View(blogToEdit);
        }

        // POST: BlogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Blog blog)
        {
            try
            {
                Blog newBlog = new Blog();
                newBlog.BlogId = blog.BlogId;
                newBlog.Name = blog.Name;
                newBlog.Description = blog.Description;
                newBlog.Created = blog.Created;
                newBlog.Modified = DateTime.Now;
                newBlog.Closed = blog.Closed;
                newBlog.Posts = blog.Posts;
                var owner = User;

                repository.SaveBlog(newBlog, owner);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET:
        // BlogController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST:
        // BlogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
