using Microsoft.AspNetCore.Mvc;
using StackSwapApplication.Services;
using StackSwapApplication.Services.DataServices;
using StackSwapApplication.ViewModels;

//By Imran and Deepthanshu 
namespace StackSwapApplication.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserAuthenticationService _authService;
        private readonly IDataService _repo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserSession _userSession;
        /// <summary>
        /// Constructor for UserController 
        /// </summary>
        /// <param name="authService"></param>
        /// <param name="repo"></param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="userSession"></param>
            
        public UserController(IUserAuthenticationService authService, IDataService repo, IHttpContextAccessor httpContextAccessor, IUserSession userSession)
        {
            _authService = authService;
            _repo = repo;
            _httpContextAccessor = httpContextAccessor;
            _userSession = userSession;
        }


        //Login get method 
        public IActionResult Login()
        {
            return View();
        }

        //Login post method 
        [HttpPost]
        public IActionResult Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                //var Users = from m in _repo.GetUsers select m;
                //var user = Users.FirstOrDefault(s => s.Username == loginVM.Username);

                //if (user != null && user.Password == loginVM.Password && user.Username != null)
                //{
                //    if (_userSession.UserLoginInfo(loginVM))
                //    {
                //        return RedirectToAction("Index", "Trade");
                //    }
                //}
                //else
                //{
                //    TempData["Error"] = "Invalid Username or Password";
                //}

                if (_authService.Login(loginVM))
                {
                    return RedirectToAction("Index", "Trade");
                }
                else
                {
                    TempData["Error"] = "Invalid Username or Password";
                }

            }
            return View();
        }

        //Logout action 
        public IActionResult Logout()
        {
            _userSession.logout();
            return RedirectToAction("MainPage", "Home");
        }


        //Get Register method 
        public IActionResult Register()
        {
            return View();
        }

        //Post Register method 
        [HttpPost]
        public IActionResult Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            if(_repo.GetUserByUsername(registerVM.Username!) != null)
            {
                ModelState.AddModelError("Username", "Username already exists");
                return View(registerVM);
            }   

            _authService.Register(registerVM);

            var loginVM = new LoginVM()
            {
                Username = registerVM.Username,
                Password = registerVM.Password
            };

            if(_authService.Login(loginVM))
            {
                return RedirectToAction("Index", "Trade");
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        //Method for view users profile 
        public IActionResult Profile()
        {
            var user = _userSession.GetCurrentUser();
            var purchases = _repo.GetPurchases.Where(p => p.BuyerId == user!.Id);
            var trades = _repo.GetTrades.Where(t => t.BuyerId == user!.Id || t.SellerId == user!.Id);
            var profileVM = new ProfileViewModel()
            {
                User = user,
                Purchases = purchases,
                Trades = trades
            };
            return View(profileVM);
        }

        public IActionResult Welcome() 
        {

            return View();
        }

    }
}
