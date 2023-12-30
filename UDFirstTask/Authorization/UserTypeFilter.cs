using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace UDFirstTask.Authorization
{
    public class UserTypeFilter : IAsyncAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly UserTypeRequirement _requirement;

        public UserTypeFilter(IAuthorizationService authorizationService, UserTypeRequirement requirement)
        {
            _authorizationService = authorizationService;
            _requirement = requirement;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var authorizationResult = await _authorizationService.AuthorizeAsync(context.HttpContext.User, null, _requirement);
            if (!authorizationResult.Succeeded)
            {
                context.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(new { controller = "Error", action = "Auth" }));

            }
        }


    }
}
