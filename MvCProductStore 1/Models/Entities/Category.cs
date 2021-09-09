using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvCProductStore_1.Models.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
