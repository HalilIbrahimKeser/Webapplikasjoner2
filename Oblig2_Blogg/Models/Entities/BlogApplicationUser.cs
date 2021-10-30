using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oblig2_Blogg.Models.Entities
{
    public class BlogApplicationUser
    {
        public string OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
