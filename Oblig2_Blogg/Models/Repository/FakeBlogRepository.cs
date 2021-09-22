using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Oblig2_Blogg.Models.Entities;

namespace Oblig2_Blogg.Models.Repository
{
    public class FakeBlogRepository : IRepository
    {
        //GET ALL
        public IEnumerable<Blog> GetAll()
        {
            string dateString = "Sep 17, 2021";
            DateTime dateCreated = DateTime.Parse(dateString);
            List<Blog> blogs = new List<Blog>{ 
                new Blog {Name = "Tur til Australia", Closed = false, Created = dateCreated, Description = "Fortelling av turopplevelser"}
            };
            return blogs;
        }

        public void Save(Blog blog)
        {
            throw new NotImplementedException();
        }

        public void Save(Blog blog, IPrincipal principal)
        {
            throw new NotImplementedException();
        }
    }
}
