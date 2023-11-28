using Microsoft.AspNetCore.Mvc;
using StackSwapApplication.Models;
using StackSwapApplication.Data;
using StackSwapApplication.Services;
//using StackSwapApplication.Services.CardServices;
//using StackSwapApplication.Services.PurchaseServices;
//using StackSwapApplication.Services.UserManagment;


namespace StackSwapApplication.Controllers
{
    public class PurchaseController : Controller
    {

        private readonly ICatalogueService _catalogueService;
        private readonly IPurchaseService _purchaseTransactionService;
        private readonly IUserSession _userSession;
        //private readonly TradeContext _tradeContext;

        public PurchaseController(ICatalogueService catalogueService, IPurchaseService purchaseTransactionService, IUserSession userSession)
        {
            _catalogueService = catalogueService;
            _purchaseTransactionService = purchaseTransactionService;
            _userSession = userSession;
            //_tradeContext = tradeContext;
        }

        public IActionResult Index()
        {
            return View(_catalogueService.GetCatalogueItems());
        }

        public IActionResult InsufficientCredits()
        {
            return View();
        }

        public IActionResult ConfirmPurchase(uint id)
        {
            CatalogueItem? catalogueItem = _catalogueService.GetCatalogueItemById(id);
            if (catalogueItem == null)
            {
                return NotFound();
            }
            return View(catalogueItem);
        }

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
