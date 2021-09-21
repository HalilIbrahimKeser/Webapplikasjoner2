using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oblig2_Blogg.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oblig2_Blogg.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        
        public ActionResult Index()
        {
            string dateString = "Sep 17, 2021";
            DateTime dateCreated = DateTime.Parse(dateString);
            string dateString1 = "Sep 17, 2021";
            DateTime dateModified = DateTime.Parse(dateString1);

            List<Blog> blogs = new List<Blog>
            {
                new Blog {Name = "Tur til Australia", Closed = false, Created = dateCreated, Modified = dateModified, Description = "Fortelling av turopplevelser"}
            };

            return View(blogs);
        }
    }
}
