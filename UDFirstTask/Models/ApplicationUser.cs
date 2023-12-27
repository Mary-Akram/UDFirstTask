using Microsoft.AspNetCore.Identity;

namespace UDFirstTask.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string UserType { get; set; }
    }
}
