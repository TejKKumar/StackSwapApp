﻿using Microsoft.AspNetCore.Mvc;
using StackSwapApplication.Services;
using StackSwapApplication.Models;
using StackSwapApplication.Data;

namespace StackSwapApplication.Controllers
{
    public class PurchaseController : Controller
    {

        private readonly ICatalogueService _catalogueService;
        private readonly IPurchaseTransactionService _purchaseTransactionService;
        private readonly IUserSession _userSession;
        private readonly TradeContext _tradeContext;

        public PurchaseController(ICatalogueService catalogueService, IPurchaseTransactionService purchaseTransactionService, IUserSession userSession, TradeContext tradeContext)
        {
            _catalogueService = catalogueService;
            _purchaseTransactionService = purchaseTransactionService;
            _userSession = userSession;
            _tradeContext = tradeContext;
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

            _purchaseTransactionService.PurchaseFromCatalogue(currentUser, newCard);

            currentUser.Credits -= catalogueItem.Credits;
            _tradeContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}
