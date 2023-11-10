using Microsoft.AspNetCore.Mvc;
using StackSwapApplication.Services;

namespace StackSwapApplication.Controllers
{
    public class TradingCardsController : Controller
    {
        public readonly ICardService cardService;   


        public TradingCardsController(ICardService cardService)
        {
            this.cardService = cardService;
        }
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult ShowCards()
        {
            
            return View(cardService.GetAllCards());
        }

    }
}
