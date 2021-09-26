using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Oblig2_Blogg.Models.ViewModels
{
    public class CreateBlogViewModel
    {
        public int BlogId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string Description { get; set; }
        
        public bool? Closed { get; set; }
        //public string Description { get; set; } not a requirement

        public DateTime Created { get; internal set; }

        public IdentityUser Owner { get; set; }
    }
}
