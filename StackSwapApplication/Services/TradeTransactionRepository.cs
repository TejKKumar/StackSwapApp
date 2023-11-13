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
            List<TradeBuyerCard> buyerTradedCards = new List<TradeBuyerCard>();
            List<TradeSellerCard> sellerTradedCards = new List<TradeSellerCard>();  
            
            
            foreach (Card card in buyerCards)
            {
                TradeBuyerCard TBC = new TradeBuyerCard();
                TBC.BuyerId = card.OwnerID;
                TBC.CardId = card.GetCardId;

                card.OwnerID = seller.GetId;
                card.Owner = seller;

                buyerTradedCards.Add(TBC);
            }

            foreach (Card card in sellerCards)
            {
                TradeSellerCard TSC = new TradeSellerCard();

                TSC.SellerId = card.OwnerID;
                TSC.CardId = card.GetCardId;

                card.OwnerID = buyer.GetId;
                card.Owner = buyer;
            }

            Trade trade = new()
            {
                Buyer = buyer,
                Seller = seller,
                buyerCardsInfo = buyerTradedCards,
                sellerCardsInfo = sellerTradedCards,
                
            };

            _tradeContext.Trades.Add(trade);
            

            trade.buyerCardsInfo.ForEach(b =>
            {
                b.TradeId = trade.Id;
                b.Trade = trade;
                _tradeContext.TradeBuyerCards.Add(b);
            });

            trade.sellerCardsInfo.ForEach(s =>
            {

                s.TradeId = trade.Id;
                s.Trade = trade;
                _tradeContext.TradeSellerCards.Add(s);
            });

            _tradeContext.SaveChanges();
        }
    }
}