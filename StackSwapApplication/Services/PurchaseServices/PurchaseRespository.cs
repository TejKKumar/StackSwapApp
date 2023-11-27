using StackSwapApplication.Data;
using StackSwapApplication.Models;
using StackSwapApplication.Services.DataServices;


namespace StackSwapApplication.Services
{
    public class PurchaseRespository : IPurchaseService
    {

        private readonly IDataService _dataService;

        public PurchaseRespository(IDataService dataService)
        {

            _dataService = dataService;
        }

        public void MakePurchase(TradeUser buyer, Card card, uint cost)
        { 

            card.Owner = buyer;
            card.OwnerID = buyer.Id;

            Purchase purchase = new Purchase();

            PurchaseCard purchaseCard = new PurchaseCard();


            _dataService.AddEntity(card);

            purchase.Buyer = buyer;
            purchase.BuyerId = buyer.Id;
            purchase.PurchaseDate = DateTime.Now;

            purchaseCard.CardId = card.Id;

            purchase.PurchaseCards = new List<PurchaseCard>() { purchaseCard };


            _dataService.AddEntity(purchase);

            //purchase.PurchaseCards.ForEach(purchaseCard =>
            //{
            //    purchaseCard.PurchaseId = purchase.Id;
            //    purchaseCard.Purchase = purchase;
            //    _dataService.AddEntity(purchaseCard);

            //});

            buyer.Credits -= cost;
            _dataService.UpdateEntity(buyer);



            //_dataService.SaveDatabaseChanges();

        }

    }
}
