using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Oblig2_Blogg.Models.Entities;
using Oblig2_BloggModels.Entities;

namespace Oblig2_Blogg.Models.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; internal set; }

        public DateTime Modified { get; internal set; }

        public bool Closed { get; set; }

        //KOMMENTAR
        public int CommentId { get; set; }

        public virtual Comment Comment { get; set; }

        //INNLEGG
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        //EIER
        public virtual IdentityUser Owner { get; set; }
    }
}
