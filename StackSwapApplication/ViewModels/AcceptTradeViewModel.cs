using StackSwapApplication.Models;

namespace StackSwapApplication.ViewModels
{
    public class AcceptTradeViewModel
    {
        public TradeUser Me { get; set; }
        public IEnumerable<Card> recievedCards { get; set; }
        public IEnumerable<Card> tradedCards { get; set; }
    }
}
