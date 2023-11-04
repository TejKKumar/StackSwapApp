using StackSwapApplication.Models;

namespace StackSwapApplication.ViewModels
{
    public class TestDataVM
    {
        public IEnumerable<Card> testCards { get; set; }
        public IEnumerable<TradeUser> testUsers { get; set; }
    }
}
