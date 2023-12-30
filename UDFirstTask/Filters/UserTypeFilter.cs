
using Microsoft.AspNetCore.Mvc.Filters;

namespace UDFirstTask.Filters
{
    public class UserTypeFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var User=context.HttpContext.User;

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
