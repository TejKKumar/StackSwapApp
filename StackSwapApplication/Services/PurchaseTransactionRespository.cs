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

            CataloguePurchase purchase = new CataloguePurchase();

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

        public void PurchaseFromUser(TradeUser buyer, TradeUser seller, Card card)
        {
            card.Owner = buyer;
            card.OwnerID = buyer.Id;

            CataloguePurchase purchase = new CataloguePurchase();

            PurchaseCard purchaseCard = new PurchaseCard();

            _tradeContext.Cards.Add(card);

            purchase.Buyer = buyer;
            purchase.BuyerId = buyer.Id;
            //purchase.Seller = seller;
            //purchase.SellerId = seller.Id;
            purchase.PurchaseDate = DateTime.Now;

            purchase.PurchaseCards = new List<PurchaseCard>
            {
                new PurchaseCard{ CardId = card.GetCardId } 
            };

            _tradeContext.Purchases.Add(purchase);

            _tradeContext.SaveChanges();
        }

    }
}
