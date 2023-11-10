using StackSwapApplication.Models;

namespace StackSwapApplication.Services
{
    public interface PurchaseTransactionService
    {

        public void AddPurchase(User user, List<Card> cards);

    }
}
