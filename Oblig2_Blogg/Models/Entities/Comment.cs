using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Oblig2_BloggModels.Entities;

namespace Oblig2_Blogg.Models.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        
        [StringLength(200)]
        public string CommentText { get; set; }

        public DateTime Created { get; internal set; }

        public DateTime Modified { get; internal set; }

        //FREMMED NØKKEL
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        //EIER
        public virtual IdentityUser Owner { get; set; }
    }
}
