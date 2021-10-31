using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oblig2_Blogg.Models.Entities
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public int PostId { get; set; }
    }
}
