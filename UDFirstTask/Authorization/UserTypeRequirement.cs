using Microsoft.AspNetCore.Authorization;

namespace UDFirstTask.Authorization
{
    public class UserTypeRequirement : IAuthorizationRequirement
    {
        public string[] AllowedUserTypes { get; }

        public UserTypeRequirement(params string[] allowedUserTypes)
        {
            AllowedUserTypes = allowedUserTypes;
        }
    }
}
