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

        //
        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get method for finding a card by champion name, this method is currently not used but is kept for expansion 
        /// </summary>
        /// <returns></returns>
        //
        [HttpGet]
        public IActionResult GetCardByName()
        {
            
            return View();
        }

        /// <summary>
        /// Post method for the search for cards with a certain Champion
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetCardByNamePost(string name)
        {
            IEnumerable<Card> clist = cardService.GetCardByName(name);
            ViewBag.ChampName = name;
            return View(clist);
        }

        //
        /// <summary>
        /// Get method for finding cards of certain tier, method currently not used but kept for expansion 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCardByTier()
        {

            return View();
        }

        //
        /// <summary>
        /// Post method for finding the cards of a certain tier
        /// </summary>
        /// <param name="tier"></param>
        /// <returns></returns>
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
