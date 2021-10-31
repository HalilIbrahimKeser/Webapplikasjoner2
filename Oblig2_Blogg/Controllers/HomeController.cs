using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Oblig2_Blogg.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Oblig2_Blogg.Models.Entities;
using Oblig2_Blogg.Models.Repository;
using Oblig2_Blogg.Models.ViewModels;

namespace Oblig2_Blogg.Controllers
{
  
    public class HomeController : Controller
    {
        private readonly IRepository repository;
        private UserManager<ApplicationUser> userManager;
        private IAuthorizationService authService;

        public HomeController(IRepository repository, UserManager<ApplicationUser> userManager1 = null, IAuthorizationService authorizationService1 = null)
        {
            this.repository = repository;
            this.userManager = userManager1;
            this.authService = authorizationService1;
        }

        public IActionResult Index()
        {
            var user = userManager.GetUserAsync(User).Result;

            var blogs = repository.GetAllSubscribedBlogs(user);
            var posts = repository.GetAllLastPostsWhitBlog();
            var tags = repository.GetAllTags();
            var comments = repository.GetAllComments();

            IndexViewModel indexViewModel = new IndexViewModel()
            {
                Blogs = blogs,
                Posts = posts,
                Tags = tags,
                Comments = comments
            };

            return View(indexViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
