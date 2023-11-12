using Microsoft.AspNetCore.Mvc;
using StackSwapApplication.Services;
using StackSwapApplication.Models;

namespace StackSwapApplication.Controllers
{
    public class PurchaseController : Controller
    {

        private readonly ICatalogueService _catalogueService;
        private readonly IPurchaseTransactionService _purchaseTransactionService;
        private readonly IUserSession _userSession;

        public PurchaseController(ICatalogueService catalogueService, IPurchaseTransactionService purchaseTransactionService, IUserSession userSession)
        {
            _catalogueService = catalogueService;
            _purchaseTransactionService = purchaseTransactionService;
            _userSession = userSession;
        }

        public IActionResult Index()
        {
            return View(_catalogueService.GetCatalogueItems());
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

            Card newCard;
            _catalogueService.CreateCard(out newCard, catalogueItem);

            _purchaseTransactionService.MakePurchase(_userSession.GetCurrentUser()!, newCard);

            return RedirectToAction("Index", "Home");
        }

    }
}
