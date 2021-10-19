using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Oblig2_Blogg.Models.Entities
{
    public class Blog
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
        public virtual ApplicationUser Owner { get; set; }
    }
}
