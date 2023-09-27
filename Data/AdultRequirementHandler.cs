﻿using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
namespace Market.Data
{
    public class AdultRequirementHandler : AuthorizationHandler<AdultRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdultRequirement requirement)
        {
            var (value, isSuccess) = TryRetriveValue(context);
            if (isSuccess && value >=18)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }

        private static (int, bool) TryRetriveValue(AuthorizationHandlerContext context)
        {
            string value = context.User.FindFirst(ct => ct.Type == AdultRequirement.ClaimName)?.Value;

            if (!string.IsNullOrEmpty(value))
            {
                int age = Convert.ToInt32(value);

                return (age, true);
            }
            else
            {
                return (0, false);
            }
        }
    }
}
