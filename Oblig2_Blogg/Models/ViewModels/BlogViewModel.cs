using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Oblig2_Blogg.Models.Entities;

namespace Oblig2_Blogg.Models.ViewModels
{
    public class BlogViewModel
    {
        public int BlogId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        public bool Closed { get; set; }

        //Blog
        public Blog blog { get; set; }


        //INNLEGG
        public virtual List<Post> Posts { get; set; }

        public virtual List<Tag> Tags { get; set; }

        //EIER
        public virtual ApplicationUser Owner { get; set; }
    }
}
