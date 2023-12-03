using Microsoft.AspNetCore.Mvc;
using StackSwapApplication.Models;
using StackSwapApplication.Services;

//By Rashesh 
namespace StackSwapApplication.Controllers
{
    public class TradingCardsController : Controller
    {
        public readonly ICardService cardService;   

        /// <summary>
        /// Contructor for TradingCardsController
        /// </summary>
        /// <param name="cardService"></param>
        public TradingCardsController(ICardService cardService)
        {
            this.cardService = cardService;
        }

        //Index
        public IActionResult Index()
        {
            return View();
        }

        //Get method for finding a card by champion name, this method is currently not used but is kept for expansion 
        [HttpGet]
        public IActionResult GetCardByName()
        {
            
            return View();
        }

        //Post method for the search for cards with a certain Champion
        [HttpPost]
        public IActionResult GetCardByNamePost(string name)
        {
            IEnumerable<Card> clist = cardService.GetCardByName(name);
            ViewBag.ChampName = name;
            return View(clist);
        }

        //Get method for finding cards of certain tier, method currently not used but kept for expansion 
        [HttpGet]
        public IActionResult GetCardByTier()
        {

            return View();
        }

        //Post method for finding the cards of a certain tier
        [HttpPost]
        public IActionResult GetCardByTierPost(Tier tier)
        {
            ViewBag.ChampTier = tier;
            List<Card> tierlist = cardService.GetCardByTier(tier);
            return View(tierlist);
        }



        //Landing page for this controller
        public IActionResult ShowCards()
        {
            
            return View(cardService.GetAllCards());
        }

    }
}
