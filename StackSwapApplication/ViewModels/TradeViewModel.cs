using StackSwapApplication.Models;

namespace StackSwapApplication.ViewModels
{
    public class TradeViewModel
    {
        public Trade Trade { get; set; }
        public TradeUser Me { get; set; }
        public TradeUser Bidder { get; set; }   

        public IEnumerable<Card> MyCards { get; set; }
        public IEnumerable<Card> BidderCards { get; set; }
    }
}
