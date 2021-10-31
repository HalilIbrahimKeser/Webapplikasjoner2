using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oblig2_Blogg.Models.Entities;

namespace Oblig2_Blogg.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
