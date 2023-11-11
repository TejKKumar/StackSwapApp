﻿using Microsoft.AspNetCore.Mvc;
using StackSwapApplication.Services;
using StackSwapApplication.ViewModels;

namespace StackSwapApplication.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserAuthenticationService _authService;
        private readonly IDataService _repo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserSession _userSession;

            
        public UserController(IUserAuthenticationService authService, IDataService repo, IHttpContextAccessor httpContextAccessor, IUserSession userSession)
        {
            _authService = authService;
            _repo = repo;
            _httpContextAccessor = httpContextAccessor;
            _userSession = userSession;
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
                if(_userSession.UserLoginInfo(loginVM))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Error"] = "Invalid Username or Password";
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

        public IActionResult Welcome() 
        {

            return View();
        }

    }
}
