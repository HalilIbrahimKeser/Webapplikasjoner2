using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Oblig2_Blogg.Models.Entities;
using Oblig2_Blogg.Models.Repository;
using Oblig2_Blogg.Models.ViewModels;
using Oblig2_Blogg.Authorization;

namespace Oblig2_Blogg.Controllers
{
    public class PostController : Controller
    {
        private readonly IRepository repository;
        private UserManager<IdentityUser> userManager;
        IAuthorizationService authorizationService;

        public PostController(IRepository repository, UserManager<IdentityUser> userManager1 = null, IAuthorizationService authorizationService1 = null)
        {
            this.repository = repository;
            authorizationService = authorizationService1;
            userManager = userManager1;
        }
        public IActionResult Index()
        {
            return View(repository.GetAllPostsWhitBlog());
        }


      

    }
}
