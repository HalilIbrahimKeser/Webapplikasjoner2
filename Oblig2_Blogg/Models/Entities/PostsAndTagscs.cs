using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Oblig2_Blogg.Models.Entities
{
    public class PostsAndTags
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostsAndTagsId { get; set; }
        public int PostId { get; set; }
        public int TagId { get; set; }
    }
}
