using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MvCProductStore_1.Models.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public decimal? Price { get; set; }

        public string Class { get; internal set; }

        //Navigational Properties
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public DateTime modified { get; internal set; }

        public virtual IdentityUser Owner { get; set; }
    }
}
