using StackSwapApplication.Data;
using StackSwapApplication.Models;

namespace StackSwapApplication.Services
{
    public class PurchaseTransactionRespository : IPurchaseTransactionService
    {

        private readonly TradeContext _tradeContext;

        public PurchaseTransactionRespository(TradeContext tradeContext)
        {
            _tradeContext = tradeContext;
        }

        public void PurchaseFromCatalogue(TradeUser buyer, Card card)
        { 

            card.Owner = buyer;
            card.OwnerID = buyer.Id;

            Purchase purchase = new Purchase();

            PurchaseCard purchaseCard = new PurchaseCard();

            

            _tradeContext.Cards.Add(card);

            purchase.Buyer = buyer;
            purchase.BuyerId = buyer.Id;
            purchase.PurchaseDate = DateTime.Now;

            purchase.PurchaseCards = new List<PurchaseCard> 
            { 
                new PurchaseCard{ CardId= card.GetCardId} 
            
            };

            

            _tradeContext.Purchases.Add(purchase);

            purchase.PurchaseCards.ForEach(purchaseCard =>
            {
                purchaseCard.PurchaseId = purchase.Id;
                purchaseCard.Purchase = purchase;

            });

            _tradeContext.PurchaseCards.Add(purchaseCard);


            _tradeContext.SaveChanges();

        }

    }
}
