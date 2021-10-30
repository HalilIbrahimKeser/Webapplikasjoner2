using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Oblig2_Blogg.Models.Entities;
using Oblig2_Blogg.Models.Repository;

namespace Oblig2_Blogg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AccountsController : Controller
    {
        private readonly IAccountsRepository _accountsRepo;

        public AccountsController(IAccountsRepository accountsRepo)
        {
            _accountsRepo = accountsRepo;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("verifyLogin")]
        public async Task<IActionResult> VerifyLogin(ApplicationUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser res = await _accountsRepo.VerifyCredentials(user);

            if (res == null)
            {
                return StatusCode(401, new { res = "Brukernavn/Passord er feil" });
            }

            return new ObjectResult(_accountsRepo.GenerateJwtToken(res));
        }
    }
}
