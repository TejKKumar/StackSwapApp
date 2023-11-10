using StackSwapApplication.Models;

namespace StackSwapApplication.Services
{
    public interface PurchaseTransactionService
    {

        public void AddPurchase(TradeUser user, List<Card> cards);

    }
}
