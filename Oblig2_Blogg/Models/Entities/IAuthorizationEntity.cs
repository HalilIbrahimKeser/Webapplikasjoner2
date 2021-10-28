using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Oblig2_Blogg.Models.Entities
{
    public interface IAuthorizationEntity
    {
        [JsonIgnore]
        ApplicationUser Owner { get; set; }
    }
}
