using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Oblig2_Blogg.Models.Entities;

namespace Oblig2_BloggModels.Entities
{
    public class Post
    {
        public int PostId { get; set; }

        [StringLength(500)]
        public string PostText { get; set; }
        public DateTime Created { get; internal set; }
        public DateTime Modified { get; internal set; }

        //KOMMENTAR
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }

        //EIER
        public virtual IdentityUser Owner { get; set; }
    }
}
