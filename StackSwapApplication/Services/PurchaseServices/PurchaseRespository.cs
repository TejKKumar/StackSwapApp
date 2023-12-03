using StackSwapApplication.Data;
using StackSwapApplication.Models;
using StackSwapApplication.Services.DataServices;

//by Imran 
namespace StackSwapApplication.Services
{
    public class PurchaseRespository : IPurchaseService
    {

        private readonly IDataService _dataService;
        /// <summary>
        /// Constructor for the PurchaseRepository
        /// </summary>
        /// <param name="dataService"></param>

        public PurchaseRespository(IDataService dataService)
        {

            _dataService = dataService;
        }


        /// <summary>
        /// Method for creating a Purchase entity
        /// </summary>
        /// <param name="buyer"></param>
        /// <param name="card"></param>
        /// <param name="cost"></param>
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

            buyer.Credits -= cost;
            _dataService.UpdateEntity(buyer);


        }

    }
}
