using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Oblig2_Blogg.Models.Entities
{
    public class Tag
    {
        public Tag()
        {
            this.Posts = new HashSet<Post>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagId { get; set; }
       
        [Required]
        [StringLength(50)]
        public string TagLabel { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        //FREMMED NØKKEL
        //[ForeignKey("PostId")]
        [Required]
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        //POSTER
        public virtual ICollection<Post> Posts { get; set; }
    }
}
