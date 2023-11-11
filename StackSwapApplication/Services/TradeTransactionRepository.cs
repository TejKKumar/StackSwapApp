using StackSwapApplication.Data;
using StackSwapApplication.Models;

namespace StackSwapApplication.Services
{
    public class TradeTransactionRepository : TradeTransactionService
    {

        private readonly TradeContext _tradeContext;

        public TradeTransactionRepository(TradeContext tradeContext)
        {
            _tradeContext = tradeContext;
        }

        public void MakeTrade(TradeUser buyer, TradeUser seller, List<Card> buyerCards, List<Card> sellerCards)
        {
            foreach (Card card in buyerCards)
            {
                card.OwnerID = seller.GetId;
                card.Owner = seller;
            }

            foreach (Card card in sellerCards)
            {
                card.OwnerID = buyer.GetId;
                card.Owner = buyer;
            }

            Trade trade = new()
            {
                Buyer = buyer,
                Seller = seller,
                buyerCards = buyerCards,
                sellerCards = sellerCards
            };

            _tradeContext.Trades.Add(trade);
            _tradeContext.SaveChanges();

        }
    }
}