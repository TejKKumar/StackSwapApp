using StackSwapApplication.Data;
using StackSwapApplication.Models;

namespace StackSwapApplication.Services
{
    public class PurchaseTransactionRespository : PurchaseTransactionService
    {

        private readonly TradeContext _tradeContext;

        public PurchaseTransactionRespository(TradeContext tradeContext)
        {
            _tradeContext = tradeContext;
        }

        public void AddPurchase(User buyer, List<Card> cards)
        {
            foreach (Card card in cards)
            {
                card.OwnerID = buyer.GetId;
                card.Owner = buyer;
            }
            Purchase purchase = new()
            {
                Cards = cards,
                Buyer = buyer,
                PurchaseDate = DateTime.Now
            };

            _tradeContext.Purchases.Add(purchase);
            _tradeContext.SaveChanges();

        }

    }
}
