using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Oblig2_Blogg.Models.Entities;

namespace Oblig2_Blogg.Models.Repository
{
    public interface IRepository
    {
        IEnumerable<Blog> GetAll();

        void Save(Blog blog, IPrincipal principal);
    }
}
