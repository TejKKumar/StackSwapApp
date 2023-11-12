using StackSwapApplication.Models;

namespace StackSwapApplication.Services
{
    public interface IPurchaseTransactionService
    {

        public void MakePurchase(TradeUser user, Card card);

    }
}
