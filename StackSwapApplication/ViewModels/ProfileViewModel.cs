using StackSwapApplication.Models;

namespace StackSwapApplication.ViewModels
{
    public class ProfileViewModel
    {

        public TradeUser? User { get; set; }
        public IEnumerable<Trade>? Trades { get; set; }
        public IEnumerable<Purchase>? Purchases { get; set; }

    }
}
