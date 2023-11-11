using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using StackSwapApplication.Services;
using StackSwapApplication.ViewModels;

namespace StackSwapApplication.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserAuthenticationService _authService;

        public UserController(IUserAuthenticationService authService)
        {
            _authService = authService;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            _authService.Register(registerVM);

            return RedirectToAction("Index", "Home");
        }

    }
}
