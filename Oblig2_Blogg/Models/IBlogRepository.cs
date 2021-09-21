using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oblig2_Blogg.Models.Entities;

namespace Oblig2_Blogg.Models
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> GetAll();

        void Save(Blog blog);
    }
}
