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


        //
        /// <summary>
        /// Login get method 
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }

        //
        /// <summary>
        /// Login post method 
        /// </summary>
        /// <param name="loginVM"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {

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
        /// <summary>
        /// Logout action 
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            _userSession.logout();
            return RedirectToAction("MainPage", "Home");
        }

        /// <summary>
        /// Get Register method 
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }

        //
        /// <summary>
        /// Post Register method 
        /// </summary>
        /// <param name="registerVM"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            if(_repo.GetUsers.SingleOrDefault(u => u.Username == registerVM.Username) != null)
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

        /// <summary>
        /// Method for view users profile
        /// </summary>
        /// <returns></returns>
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
