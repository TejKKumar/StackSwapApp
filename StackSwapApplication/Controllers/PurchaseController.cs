using Microsoft.AspNetCore.Mvc;
using StackSwapApplication.Models;
using StackSwapApplication.Data;
using StackSwapApplication.Services;
//using StackSwapApplication.Services.CardServices;
//using StackSwapApplication.Services.PurchaseServices;
//using StackSwapApplication.Services.UserManagment;


//By Imran
namespace StackSwapApplication.Controllers
{
    public class PurchaseController : Controller
    {

        private readonly ICatalogueService _catalogueService;
        private readonly IPurchaseService _purchaseTransactionService;
        private readonly IUserSession _userSession;
        /// <summary>
        /// Constructor the the Purchase Controller
        /// </summary>
        /// <param name="catalogueService"></param>
        /// <param name="purchaseTransactionService"></param>
        /// <param name="userSession"></param>

        public PurchaseController(ICatalogueService catalogueService, IPurchaseService purchaseTransactionService, IUserSession userSession)
        {
            _catalogueService = catalogueService;
            _purchaseTransactionService = purchaseTransactionService;
            _userSession = userSession;
        }

        //Landing page for this controller 
        public IActionResult Index()
        {
            return View(_catalogueService.GetCatalogueItems());
        }

        //Error message action result for stating that the user does not have sufficient credits 
        public IActionResult InsufficientCredits()
        {
            return View();
        }

        //
        /// <summary>
        /// Confirmation of a purchase 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult ConfirmPurchase(uint id)
        {
            CatalogueItem? catalogueItem = _catalogueService.GetCatalogueItemById(id);
            if (catalogueItem == null)
            {
                return NotFound();
            }
            return View(catalogueItem);
        }

        //
        /// <summary>
        /// Make a purchase 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult MakePurchase(uint id)
        {
            CatalogueItem? catalogueItem = _catalogueService.GetCatalogueItemById(id);
            if (catalogueItem == null)
            {
                return NotFound();
            }

            TradeUser currentUser = _userSession.GetCurrentUser()!;

            if(currentUser.Credits < catalogueItem.Credits)
            {
                return RedirectToAction("InsufficientCredits");
            }

            Card newCard;
            _catalogueService.CreateCard(out newCard, catalogueItem);

            _purchaseTransactionService.MakePurchase(currentUser, newCard, catalogueItem.Credits);

            //currentUser.Credits -= catalogueItem.Credits;
            //_tradeContext.SaveChanges();

            return RedirectToAction("Index", "Trade");
        }

    }
}
