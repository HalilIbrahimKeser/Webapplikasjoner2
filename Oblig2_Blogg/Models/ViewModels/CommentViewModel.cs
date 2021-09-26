using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Oblig2_Blogg.Models.Entities;

namespace Oblig2_Blogg.Models.ViewModels
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }

        public string CommentText { get; set; }

        public DateTime Created { get; internal set; }

        public DateTime? Modified { get; internal set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public virtual IdentityUser Owner { get; set; }
    }
}
