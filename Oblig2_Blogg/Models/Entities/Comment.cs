using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Oblig2_Blogg.Models.Entities
{
   
    public class Comment : IAuthorizationEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        
        [StringLength(200)]
        [Required]
        public string CommentText { get; set; }

        public DateTime Created { get; internal set; }

        public DateTime? Modified { get; internal set; }

        //FREMMED NØKKEL
        [Required]
        [ForeignKey("FK_PostId")]
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        //EIER
        [JsonIgnore]
        public virtual ApplicationUser Owner { get; set; }
    }
}
