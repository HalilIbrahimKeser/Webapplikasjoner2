using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Oblig2_Blogg.Models.Entities
{
    public class Blog : IAuthorizationEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Blog")]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        public bool Closed { get; set; }

        //INNLEGG
        public virtual List<Post> Posts { get; set; }

        //EIER
        [JsonIgnore]
        public virtual ApplicationUser Owner { get; set; }

        //ABONNENTER
        //public virtual ICollection<ApplicationUser> SubscribedUser { get; set; }

    }
}
