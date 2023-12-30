using Microsoft.AspNetCore.Identity;

namespace UDFirstTask.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string UserType { get; set; }

        public static IEnumerable<ApplicationUser> GetDefaultUsers()
        {
            return new List<ApplicationUser>
        {
            new ApplicationUser
            {
                Id = "1",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com",
                EmailConfirmed = true,
                PasswordHash = "admin123",
                SecurityStamp = "SampleStamp456",
                ConcurrencyStamp = "SampleConcurrency789",
                UserType = "Admin"
            },
            new ApplicationUser
            {
                Id = "2",
                UserName = "mary",
                NormalizedUserName = "CLIENT",
                Email = "client@gmail.com",
                NormalizedEmail = "client@gmail.com",
                EmailConfirmed = true,
                PasswordHash = "client123",
                SecurityStamp = "SampleStamp123",
                ConcurrencyStamp = "SampleConcurrency456",
                UserType = "Client"
            }
        };
     }
    }
}
