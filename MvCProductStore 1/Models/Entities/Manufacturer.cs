using System.Collections.Generic;

namespace MvCProductStore_1.Models.Entities
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public virtual List<Product> Products { get; set; } 
    }
}