using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Oblig2_Blogg.Models.Entities;

namespace Oblig2_Blogg.Authorization
{
    public class BlogOwnerAuthorizationHandler
        : AuthorizationHandler<OperationAuthorizationRequirement, IAuthorizationEntity>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public BlogOwnerAuthorizationHandler(UserManager<ApplicationUser>
            userManager)
        {
            _userManager = userManager;
        }

        protected override Task
             HandleRequirementAsync(
                 AuthorizationHandlerContext context, 
                 OperationAuthorizationRequirement requirement,
                 IAuthorizationEntity resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            // If we're not asking for CRUD permission, return.

            if (requirement.Name != Constants.CreateOperationName &&
                requirement.Name != Constants.ReadOperationName &&
                requirement.Name != Constants.UpdateOperationName &&
                requirement.Name != Constants.DeleteOperationName)
            {
                return Task.CompletedTask;
            }

            //TODO flytt sjekk for blog closed til hit

            if (resource.Owner.Id == _userManager.GetUserId(context.User))
            { 
                context.Succeed(requirement);
            }


            return Task.CompletedTask;
        }
    }
}
