
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting.Internal;
using Oblig2_Blogg.Data;
using Oblig2_Blogg.Models.Entities;
using Oblig2_Blogg.Models.Repository;

namespace Oblig2_Blogg.Models
{
    /// <summary>
    /// Repository for handling interactions with database pertaining ApplicationUser
    /// </summary>
    /// <see cref="ApplicationUser"/>
    public class AccountsRepository : IAccountsRepository
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _conf;

        public AccountsRepository(SignInManager<ApplicationUser> manager, UserManager<ApplicationUser> userManager, ApplicationDbContext _db,  IConfiguration conf)
        {
            _conf = conf;
            _signInManager = manager;
            _userManager = userManager;
        }

        public async Task<ApplicationUser> VerifyCredentials(ApplicationUser user)
        {
            if (user.UserName == null || user.Password == null || user.UserName.Length == 0 || user.Password.Length == 0)
            {
                return null;
            }

            var thisUser = await _userManager.FindByNameAsync(user.UserName);
            if (thisUser == null)
                return (null);
            
            var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, lockoutOnFailure: true);
            if (!result.Succeeded)
            {
                return null;
            }
            
            return new ApplicationUser()
                {Id = thisUser.Id, UserName = user.UserName };
        }

        public string GenerateJwtToken(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var confKey = _conf.GetSection("TokenSettings")["SecretKey"];
            var key = Encoding.ASCII.GetBytes(confKey);
            var cIdentity = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                });


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = cIdentity,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
            
            
        }


        public Task<ApplicationUser> ChangeRole(ApplicationUser u, string newR)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(ApplicationUser u)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> AddUser(ApplicationUser u)
        {
            throw new NotImplementedException();
        }

        public Task<List<ApplicationUser>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangePassword(ApplicationUser u, string oldP, string newP)
        {
            throw new NotImplementedException();
        }
    }
}
