using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Oblig2_Blogg.Models.Entities;

namespace Oblig2_Blogg.Models.Entities
{
    public class Post : IAuthorizationEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }

        [StringLength(200)]
        [Required]
        [Display(Name = "Post")]
        public string PostText { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        //FREMMED NØKKEL
        [Required]
        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; }

        //KOMMENTARER
        public virtual List<Comment> Comments { get; set; }

        //TAG
        public virtual ICollection<Tag> Tags { get; set; }

        //EIER
        [JsonIgnore]
        public virtual ApplicationUser Owner { get; set; }
    }
}
