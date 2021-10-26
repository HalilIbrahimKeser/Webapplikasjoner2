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
    public class CommentOwnerAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Comment>
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public CommentOwnerAuthorizationHandler (UserManager<ApplicationUser>
            userManager)
        {
            _userManager = userManager;
        }

        protected override async Task<Task> HandleRequirementAsync(
            AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement,
            Comment resource)
        {
            if (context.User == null || resource == null)
            { 
                return Task.CompletedTask;
            }

            if (requirement.Name != Constants.CreateOperationName &&
                requirement.Name != Constants.ReadOperationName &&
                requirement.Name != Constants.UpdateOperationName &&
                requirement.Name != Constants.DeleteOperationName)
            {
                return Task.CompletedTask;
            }

            if (resource.Owner.Id == _userManager.GetUserId(context.User))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}

