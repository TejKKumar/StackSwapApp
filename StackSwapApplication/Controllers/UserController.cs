using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using StackSwapApplication.Services;
using StackSwapApplication.ViewModels;

namespace StackSwapApplication.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserAuthenticationService _authService;
        private readonly IDataService _repo;

            
        public UserController(IUserAuthenticationService authService, IDataService repo)
        {
            _authService = authService;
            _repo = repo;

        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var Users = from m in _repo.GetUsers select m;
                var User = Users.FirstOrDefault(s => s.Username == (loginVM.Username));
                if(User == null)
                {
                    return View();
                }
                if (User.Password == loginVM.Password)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
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
