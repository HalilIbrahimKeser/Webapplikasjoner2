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
    public class PostViewModel
    {
        public int PostId { get; set; }

        public string PostText { get; set; }

        public DateTime Created { get; internal set; }

        public DateTime? Modified { get; internal set; }

        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public virtual ApplicationUser Owner { get; set; }
    }
}
