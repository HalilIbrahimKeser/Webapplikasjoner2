using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Oblig2_Blogg.Models.Entities
{
    interface IAuthorizationEntity
    {
        ApplicationUser Owner { get; set; }
    }
}
