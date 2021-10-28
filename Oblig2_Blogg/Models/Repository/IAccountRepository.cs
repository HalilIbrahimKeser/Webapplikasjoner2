using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oblig2_Blogg.Models.Entities;

namespace Oblig2_Blogg.Models.Repository
{
    public interface IAccountsRepository
    {

        Task<ApplicationUser> VerifyCredentials(ApplicationUser user);
        string GenerateJwtToken(ApplicationUser user);
        Task<bool> ChangePassword(ApplicationUser u, string oldP, string newP);
        Task<ApplicationUser> ChangeRole(ApplicationUser u, string newR);
        Task<bool> DeleteUser(ApplicationUser u);
        Task<ApplicationUser> AddUser(ApplicationUser u);
        Task<List<ApplicationUser>> GetAllUsers();
    }
}
