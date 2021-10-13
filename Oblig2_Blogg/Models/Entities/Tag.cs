using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oblig2_Blogg.Models.Entities
{
    public class Tag 
    {
        public int TagId { get; set; }

        public string TagLabel { get; set; }

        public DateTime Created { get; internal set; }

        public DateTime? Modified { get; internal set; }

        public int PostId { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}
