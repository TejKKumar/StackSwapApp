using StackSwapApplication.Data;
using StackSwapApplication.Models;
using StackSwapApplication.ViewModels;

namespace StackSwapApplication.Services
{
    public class TradeManager : ITradeService
    {

        private readonly TradeContext _tradeContext;

        public TradeManager(TradeContext tradeContext)
        {
            _tradeContext = tradeContext;
        }

        private void MarkCardUnavailable(uint id)
        {
            var card = _tradeContext.Cards.Single(c=>c.Id == id);
            card.Available = false;
            _tradeContext.Cards.Update(card);
        }

        public Trade MakeTradeRequest(uint buyerID, uint sellerID, List<uint> buyerCardIDs, List<uint> sellerCardIDs)
        {
            List<TradeBuyerCard> buyerTradedCards = new List<TradeBuyerCard>();
            List<TradeSellerCard> sellerTradedCards = new List<TradeSellerCard>();

            foreach (uint id in buyerCardIDs)
            {
                TradeBuyerCard TBC = new TradeBuyerCard();
                TBC.BuyerId = buyerID;
                TBC.CardId = id;

                MarkCardUnavailable(id);

                buyerTradedCards.Add(TBC);
            }

            foreach (uint id in sellerCardIDs)
            {
                TradeSellerCard TSC = new TradeSellerCard();

                TSC.SellerId = sellerID;
                TSC.CardId = id;

                MarkCardUnavailable(id);

               sellerTradedCards.Add(TSC);
            }
            Trade trade = new()
            {
                BuyerId = buyerID,
                Buyer = _tradeContext.Users.Single(u=>u.Id == buyerID),
                SellerId = sellerID,
                Seller = _tradeContext.Users.Single(u=>u.Id == sellerID),
                buyerCardsInfo = buyerTradedCards,
                sellerCardsInfo = sellerTradedCards,
                InitatedDate = DateTime.Now,
            };

            _tradeContext.Trades.Add(trade);

            trade.buyerCardsInfo.ForEach(b=> {
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
            return trade;
            

        }

        public void MakeTrade(TradeUser buyer, TradeUser seller, List<Card> buyerCards, List<Card> sellerCards)
        {
            List<TradeBuyerCard> buyerTradedCards = new List<TradeBuyerCard>();
            List<TradeSellerCard> sellerTradedCards = new List<TradeSellerCard>();  
            
            
            foreach (Card card in buyerCards)
            {
                TradeBuyerCard TBC = new TradeBuyerCard();
                TBC.BuyerId = buyer.Id;
                TBC.CardId = card.GetCardId;

                card.OwnerID = seller.GetId;
                card.Owner = seller;

                buyerTradedCards.Add(TBC);
            }

            foreach (Card card in sellerCards)
            {
                TradeSellerCard TSC = new TradeSellerCard();

                TSC.SellerId = seller.Id;
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

        public AcceptTradeViewModel AcceptTrade(uint Id)
        {
            Trade trade = _tradeContext.Trades.Single(t => t.Id == Id);
            List<Card> recivedCards = new List<Card>();
            List<Card> tradedCards = new List<Card>();
            TradeUser Me = _tradeContext.Users.Single(u => u.Id == trade.SellerId);

            trade.buyerCardsInfo.ForEach((b) =>
            {

                var Card = _tradeContext.Cards.Single(c => c.Id == b.CardId);
                Card.OwnerID = trade.SellerId;
                Card.Owner = trade.Seller;
                Card.Available = true;

                _tradeContext.Update(Card);
                recivedCards.Add(Card);

            });

            trade.sellerCardsInfo.ForEach(s =>
            {
                var Card = _tradeContext.Cards.Single(c => c.Id == s.CardId);
                Card.OwnerID = trade.BuyerId;
                Card.Owner = trade.Buyer;
                Card.Available = true;
                _tradeContext.Update(Card);
                tradedCards.Add(Card);
            });

            trade.IsAccepted = true;
            trade.IsComplete = true;
            trade.CompletedDate = DateTime.Now;
            _tradeContext.Update(trade);
             _tradeContext.SaveChanges();

            AcceptTradeViewModel vm = new AcceptTradeViewModel()
            {
                Me = Me,
                recievedCards = recivedCards.AsEnumerable(),
                tradedCards = tradedCards.AsEnumerable()
            };

            return vm;
        }

        public RejectTradeViewModel RejectTrade(uint Id)
        {
            Trade trade = _tradeContext.Trades.Single(t =>  t.Id == Id);
            List<Card> rejectedCards = new List<Card>();
            TradeUser me = _tradeContext.Users.Single(u => u.Id == trade.SellerId);

            trade.buyerCardsInfo.ForEach(s =>
            {
                var Card = _tradeContext.Cards.Single(c => c.Id == s.CardId);
                rejectedCards.Add(Card);
            });

            trade.IsAccepted = false;
            trade.IsComplete = true;
            trade.CompletedDate= DateTime.Now;
            _tradeContext.Update(trade);
            _tradeContext.SaveChanges();

            RejectTradeViewModel vm = new RejectTradeViewModel()
            {
                Me = me,
                rejectedCards = rejectedCards.AsEnumerable(),
            };



            return vm;

        }
    }
}