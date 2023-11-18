using StackSwapApplication.Models;

namespace StackSwapApplication.ViewModels
{
    public class RejectTradeViewModel
    {
        public TradeUser Me { get; set; }
        public IEnumerable<Card> rejectedCards { get; set; }
       
    }
}
