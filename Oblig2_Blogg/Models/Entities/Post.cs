using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Oblig2_Blogg.Models.Entities;

namespace Oblig2_Blogg.Models.Entities
{
    public class Post
    {

        //PostId, PostText, Created, Modified, BlogId, Blog, Comments, Owner


        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }

        [StringLength(200)]
        [Required]
        [Display(Name = "Post")]
        public string PostText { get; set; }

        public DateTime Created { get; internal set; }

        public DateTime? Modified { get; internal set; }

        //FREMMED NØKKEL
        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; }

        //KOMMENTARER
        public virtual List<Comment> Comments { get; set; }

        //EIER
        public virtual IdentityUser Owner { get; set; }
    }
}
