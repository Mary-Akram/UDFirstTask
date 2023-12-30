using Microsoft.AspNetCore.Mvc;
using UDFirstTask.DTOs;
using UDFirstTask.Service;

namespace UDFirstTask.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthService _authService;

        public AccountController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
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
    }
}
