using StackSwapApplication.Models;

namespace StackSwapApplication.ViewModels
{
    public class ViewCardsVM
    {
        public TradeUser Buyer { get; set; }
        public IEnumerable<Card> BuyerCards {  get; set; } 

        public TradeUser Seller { get; set; }
        public IEnumerable<Card> SellerCards { get; set; }
    }
}
