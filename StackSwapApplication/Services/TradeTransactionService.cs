using StackSwapApplication.Models;

namespace StackSwapApplication.Services
{
    public interface TradeTransactionService
    {
        public void MakeTrade(TradeUser user1, TradeUser user2, List<Card> user1Cards, List<Card> user2Cards);
    }

}