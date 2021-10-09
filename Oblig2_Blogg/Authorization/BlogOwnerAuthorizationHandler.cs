﻿using System;
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
        : AuthorizationHandler<OperationAuthorizationRequirement, Blog>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public BlogOwnerAuthorizationHandler(UserManager<IdentityUser>
            userManager)
        {
            _userManager = userManager;
        }

        protected override async Task<Task>
             HandleRequirementAsync(
                 AuthorizationHandlerContext context, 
                 OperationAuthorizationRequirement requirement, 
                 Blog resource)
        {
            if (context.User == null || resource == null)
            {
                // Return Task.FromResult(0) if targeting a version of
                // .NET Framework older than 4.6:
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

            if (resource.Owner == await _userManager.FindByEmailAsync(context.User.Identity.Name))
            {
                context.Succeed(requirement);
            }


            return Task.CompletedTask;
        }
    }
}
