using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using UDFirstTask.Data;
using UDFirstTask.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace UDFirstTask.Service
{
    public class AuthService
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AuthService(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db=db;
            _httpContextAccessor=httpContextAccessor;
        }

        public async Task<UserDTO> AuthenticateAsync(LoginDto model)
        {
            // Find the user by UserName
            var user = await _db.Users.FirstOrDefaultAsync(u => u.UserName == model.UserName);

            if (user != null)
            {
                if(model.Password == user.PasswordHash) 
                {
                  var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim("UserType", user.UserType),
                        new Claim(ClaimTypes.Email, user.Email)
                    };

                    // Create a ClaimsIdentity
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    // Sign in the user
                    await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


                    return new UserDTO
                    {
                        UserName = model.UserName,
                        PasswordHash = user.PasswordHash,
                        PhoneNumber= user.PhoneNumber,
                        Email = user.Email,
                        AccessFailedCount= user.AccessFailedCount,
                        ConcurrencyStamp=user.ConcurrencyStamp,
                        EmailConfirmed=user.EmailConfirmed,
                        Id= user.Id,
                        LockoutEnabled=user.LockoutEnabled,
                        LockoutEnd=user.LockoutEnd,
                        NormalizedEmail=user.NormalizedEmail,
                         NormalizedUserName=user.NormalizedUserName,
                        PhoneNumberConfirmed=user.PhoneNumberConfirmed,
                        SecurityStamp=user.SecurityStamp,
                       TwoFactorEnabled=user.TwoFactorEnabled,
                       UserType=user.UserType,    


                    };
                }
            
            }

            // User not found or password incorrect
            return null;
        }
    }

}
