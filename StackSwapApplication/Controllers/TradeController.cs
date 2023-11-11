using Microsoft.AspNetCore.Mvc;
using StackSwapApplication.Services;

namespace StackSwapApplication.Controllers
{
    public class TradeController : Controller
    {
        public ICardService _repo;
        public TradeController(ICardService repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MakeTrade()
        {
            var cards = _repo.GetAllCards();
            return View(cards);
        }
    }
}
