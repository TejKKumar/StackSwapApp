using StackSwapApplication.Models;

//By Imran 
namespace StackSwapApplication.Services
{
    public interface IPurchaseService
    {

        public void MakePurchase(TradeUser user, Card card, uint itemCost);

    }
}
