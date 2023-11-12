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

        public void MakePurchase(TradeUser buyer, Card card)
        { 

            card.Owner = buyer;
            card.OwnerID = buyer.Id;

            _tradeContext.Cards.Add(card);
            _tradeContext.SaveChanges();

        }

    }
}
