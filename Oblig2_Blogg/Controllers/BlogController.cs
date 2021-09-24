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

        //CONSTRUCTOR
        public BlogController(IRepository repository)
        {
            this.repository = repository;
            //this.manager = manager;
        }

        //VIEW
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(repository.GetAllBlogs());
        }

        //VIEW
        [AllowAnonymous]
        public ActionResult ReadBlog(int id)
        {
            var blog = repository.GetBlog(id);
            var posts = repository.GetAllPosts(id);

            var blogViewModel = new BlogViewModel()
            {
                BlogId = id, Name = blog.Name, 
                Description = blog.Description,
                Created = blog.Created,
                Modified = blog.Modified,
                Closed = blog.Closed,
                Owner = blog.Owner,
                Posts = posts.ToList()
            };
            return View(blogViewModel);
        }
        //VIEW
        [AllowAnonymous]
        public ActionResult ReadPost(int id)
        {
            var post = repository.GetPost(id);
            var comments = repository.GetAllComments(id);

            var postViewModel = new PostViewModel()
            {
                PostId = id,
                PostText = post.PostText,
                Created = post.Created,
                Modified = post.Modified,
                BlogId = post.BlogId,
                Comments = comments.ToList(),
                Owner = post.Owner
            };
            return View(postViewModel);
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
                    TempData["message"] = string.Format("{0} har blitt opprettet", blog.Name);
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

        // POST:
        // BlogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Blog blog)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    blog.Modified = DateTime.Now;
                    var owner = User;

                    repository.UpdateBlog(blog, owner);

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
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
