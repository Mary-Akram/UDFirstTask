using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UDFirstTask.Authorization
{
    public class UserTypeAuthorizationHandler : AuthorizationHandler<UserTypeRequirement>
    {
            private readonly IHttpContextAccessor _httpContextAccessor;

        public UserTypeAuthorizationHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            UserTypeRequirement requirement)
        {
            if (!context.User.Identity.IsAuthenticated)
            {

                context.Fail(); // Fail the authorization since the user is not authenticated

                return Task.CompletedTask;

            }

            var userTypeClaim = context.User.Claims.FirstOrDefault(c => c.Type == "UserType")?.Value;
            if (userTypeClaim != null && requirement.AllowedUserTypes.Contains(userTypeClaim))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail(); // Fail the authorization since the user type is not allowed
                return Task.CompletedTask;

            }

            return Task.CompletedTask;
        }
    }

 }


