using Microsoft.AspNetCore.Mvc;
using StackSwapApplication.Models;
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

        [HttpGet]
        public IActionResult GetCardByName()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult GetCardByNamePost(string name)
        {
            IEnumerable<Card> clist = cardService.GetCardByName(name);
            return View(clist);
        }

        [HttpGet]
        public IActionResult GetCardByTier()
        {

            return View();
        }
        [HttpPost]
        public IActionResult GetCardByTierPost(Tier tier)
        {
            List<Card> tierlist = cardService.GetCardByTier(tier);
            return View(tierlist);
        }



        public IActionResult ShowCards()
        {
            
            return View(cardService.GetAllCards());
        }

    }
}
