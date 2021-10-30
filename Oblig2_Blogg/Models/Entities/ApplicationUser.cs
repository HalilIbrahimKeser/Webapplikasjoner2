using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Oblig2_Blogg.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
        }

        public ApplicationUser(string userName) : this()
        {
            UserName = userName;
        }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Password { get; set; }

        public string Token { get; set; }

        public DateTime? LastLoggedIn { get; set; }

        public bool? IsEnabled { get; set; }

        public bool? IsAdmin { get; set; }

        public virtual ICollection<Blog> SubscribedBlogs { get; set; }
    }
}
