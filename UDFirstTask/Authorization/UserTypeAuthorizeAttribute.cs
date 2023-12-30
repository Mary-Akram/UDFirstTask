using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UDFirstTask.Authorization
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class UserTypeAuthorizeAttribute : TypeFilterAttribute
    {
        public UserTypeAuthorizeAttribute(params string[] allowedUserTypes) : base(typeof(UserTypeFilter))
        {
            Arguments = new object[] { new UserTypeRequirement(allowedUserTypes) };
        }
    }

}
