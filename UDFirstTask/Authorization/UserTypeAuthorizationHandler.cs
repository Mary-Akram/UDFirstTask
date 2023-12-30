using Microsoft.AspNetCore.Authorization;

namespace UDFirstTask.Authorization
{
    public class UserTypeAuthorizationHandler : AuthorizationHandler<UserTypeRequirement>
    {
            protected override Task HandleRequirementAsync( AuthorizationHandlerContext context,
                UserTypeRequirement requirement)
            {
                if (!context.User.Identity.IsAuthenticated)
                {
                    context.Fail();
                    return Task.CompletedTask;
                }

                var userTypeClaim = context.User.Claims.FirstOrDefault(c => c.Type == "UserType")?.Value;
                if (userTypeClaim != null && requirement.AllowedUserTypes.Contains(userTypeClaim))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    context.Fail();
                }

                return Task.CompletedTask;
            }
        }

    }


