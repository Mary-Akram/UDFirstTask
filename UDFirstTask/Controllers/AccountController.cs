using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UDFirstTask.DTOs;
using UDFirstTask.Models;
using UDFirstTask.Service;

namespace UDFirstTask.Controllers
{
    [Route("Account")]

    public class AccountController : Controller
    {
        private readonly AuthService _authService;


        public AccountController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            
                var user = await _authService.AuthenticateAsync(model);

                if (user != null)
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return View(model);
                }
            
         }

        [Route("Logout")]

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}
