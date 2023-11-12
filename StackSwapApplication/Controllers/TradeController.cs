using Microsoft.AspNetCore.Mvc;
using StackSwapApplication.Services;
using StackSwapApplication.ViewModels;

namespace StackSwapApplication.Controllers
{
    public class TradeController : Controller
    {
        public ICardService _repo;
        public IUserSession _userSession;   
        public TradeController(ICardService repo, IUserSession userSession)
        {
            _repo = repo;
            _userSession = userSession;
        }

        public IActionResult MakeTrade()
        {
            try
            {
                if (!_userSession.GetUserSession())
                {
                    TempData["Error"] = "Invalid Username or Password";
                    return RedirectToAction("Login", "User");
                }
                else
                {
                    var cards = _repo.GetAllCards();
                    return View(cards);
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Login", "User");
            }

        }
    }
}
