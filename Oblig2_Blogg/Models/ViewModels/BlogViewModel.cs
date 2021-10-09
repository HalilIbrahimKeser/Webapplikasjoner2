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

        public DateTime Created { get; internal set; }

        public DateTime? Modified { get; internal set; }

        public bool Closed { get; set; }

        //Blog
        public Blog blog { get; set; }


        //INNLEGG
        public virtual List<Post> Posts { get; set; }

        //EIER
        public virtual IdentityUser Owner { get; set; }
    }
}
