using Oblig2_Blogg.Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Oblig2_Blogg.Data;

namespace Oblig2_Blogg.Models.Repository
{
    public class Repository : IRepository
    {
        private ApplicationDbContext db;
        private UserManager<IdentityUser> manager;

        public Repository(UserManager<IdentityUser> userManager, ApplicationDbContext db)
        {
            this.db = db;
            this.manager = userManager;
        }

        public IEnumerable<Blog> GetAll()
        {
            IEnumerable<Blog> blogs = db.Blogs; 
            return db.Blogs;
        }

        [Authorize]
        public async void Save(Blog blog, IPrincipal principal)
        {
            var currentUser = manager.FindByNameAsync(principal.Identity.Name);
            var blogToSave = new Blog();
            blogToSave.Name = blog.Name;
            blogToSave.Description = blog.Description;
            blogToSave.Created = DateTime.Now;
            blogToSave.Closed = blog.Closed;
            blog.Owner = currentUser.Result;

            db.Add(blog);
            db.SaveChanges();
        }
    }
}
