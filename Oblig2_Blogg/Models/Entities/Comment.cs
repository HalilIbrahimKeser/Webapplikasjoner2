using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Oblig2_Blogg.Models.Entities
{
    //lagt inn Interface
    public class Comment : IAuthorizationEntity
    {
        //CommentId, CommentText, Created, Modified, PostId, Post, Owner


        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        
        [StringLength(200)]
        [Required]
        public string CommentText { get; set; }

        public DateTime Created { get; internal set; }

        public DateTime? Modified { get; internal set; }

        //FREMMED NØKKEL
        [Required]
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        //EIER
        public virtual ApplicationUser Owner { get; set; }
    }
}
