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
        public PostViewModel()
        {
            SelectedTags = new List<string>();
            AvailableTags = new List<Tag>();
        }

        public int PostId { get; set; }

        public string PostText { get; set; }

        public DateTime Created { get; internal set; }

        public DateTime? Modified { get; internal set; }

        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        //Tags select menu for create post
        //https://stackoverflow.com/questions/37778489/how-to-make-check-box-list-in-asp-net-mvc/37779070
        public IList<string> SelectedTags { get; set; }
        public IList<Tag> AvailableTags { get; set; }

        public virtual ApplicationUser Owner { get; set; }
    }
}
