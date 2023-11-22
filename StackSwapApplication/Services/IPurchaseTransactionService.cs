using StackSwapApplication.Models;

namespace StackSwapApplication.Services
{
    public interface IPurchaseTransactionService
    {

        public void PurchaseFromCatalogue(TradeUser user, Card card);

        public void PurchaseFromUser(TradeUser buyer, TradeUser seller, Card card);

    }
}
