﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oblig2_Blogg.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Oblig2_Blogg.Authorization;
using Oblig2_Blogg.Models.Repository;
using Oblig2_Blogg.Models.ViewModels;

namespace Oblig2_Blogg.Controllers
{
    public class BlogController : Controller
    {
        private readonly IRepository repository;
        private UserManager<ApplicationUser> userManager;
        IAuthorizationService authorizationService;
        private IAuthorizationService authService;


        //CONSTRUCTOR-----------------------------------------------
        // UserManager<ApplicationUser> userManager1 = null,
        public BlogController(IRepository repository, UserManager<ApplicationUser> userManager1, IAuthorizationService authorizationService1 = null)
        {
            this.repository = repository;
            this.userManager = userManager1;
            this.authorizationService = authorizationService1;
        }

        //public BlogController(IRepository @object, IAuthorizationService authService)
        //{
        //    this.@object = @object;
        //    this.authService = authService;
        //}

        //VIEWS---------------------------------------------------

        //VIEW
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(repository.GetAllBlogs());
        }

        //VIEW
        [AllowAnonymous]
        public ActionResult ReadBlogPosts(int id)
        {
           
            Blog blog = repository.GetBlog(id);
            List<Post> posts = new List<Post>();
            posts = repository.GetAllPosts(id).ToList();
            List<Tag> tagsForThisBlog = repository.GetAllTagsForBlog(blog.BlogId).ToList();

            if (ModelState.IsValid)
            {
                BlogViewModel blogViewModel = new BlogViewModel()
                {
                    BlogId = id,
                    Name = blog.Name,
                    Description = blog.Description,
                    Created = blog.Created,
                    Modified = blog.Modified,
                    Closed = blog.Closed,
                    Owner = blog.Owner,
                    Posts = posts.ToList(),
                    Tags = tagsForThisBlog
                };
                return View(blogViewModel);
            }
            else
            {
                return View();
            }
        }

        //VIEW
        [AllowAnonymous]
        public ActionResult ReadPostComments(int PostId)
        {
            TempData["chosenId"] = PostId;
            var postViewModel = repository.GetPostViewModel(PostId);

            return View(postViewModel);
        }

        //BLOG CRUD OPERATIONS------------------------------------------------------------------------
        
        // Blog/Create
        [HttpGet]
        public ActionResult Create() { return View(); }

        // Blog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name, Description, Created, Closed, Owner")] CreateBlogViewModel blogViewModel) 
        { 
            try {
                if (ModelState.IsValid) {
                    var blog = new Blog() {
                        Name = blogViewModel.Name,
                        Description = blogViewModel.Description,
                        Created = DateTime.Now,
                        Closed = blogViewModel.Closed,
                    };
                    repository.SaveBlog(blog, User).Wait();
                    TempData["Feedback"] = string.Format("{0} har blitt opprettet", blog.Name);
                    return RedirectToAction(nameof(Index));
                }
            } catch (Exception e)
            { Console.WriteLine(e);
                return View();
            }
            return View();
        }

        public ActionResult SubscribeToBlog(int id) {
            Blog blog = repository.GetBlog(id);
            //var userId = userManager.GetUserId(User);
            var userTemp = userManager.GetUserAsync(User);

            ApplicationUser user = userTemp.Result;
            try
            {
                repository.SubscribeToBlog(blog, user);
                TempData["Feedback"] = $"Du er abonnert på blog nr: {blog.BlogId}";
                return RedirectToAction("Index", "Blog");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return RedirectToAction("Index", "Blog");
            }

            return RedirectToAction("Index", "Blog");
        }
      
    }
}
