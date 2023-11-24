using StackSwapApplication.Data;
using StackSwapApplication.Models;
using StackSwapApplication.Services.DataServices;
using StackSwapApplication.ViewModels;

//Created by Deeptanshu, completed by Tejas Kumar
namespace StackSwapApplication.Services
{
    public class TradeManager : ITradeService
    {


        private readonly IDataService _dataService;

        /// <summary>
        /// Constructor for Trade Manager which injects dependency on IDataService
        /// </summary>
        /// <param name="dataService"></param>
        public TradeManager(IDataService dataService)
        {
            _dataService = dataService;
        }

        private void MarkCardUnavailable(uint id)
        {
            var card = _dataService.GetCards.Single(c=>c.Id == id);
            card.Available = false;
            _dataService.UpdateEntity(card);
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
                Buyer = _dataService.GetUsers.Single(u=>u.Id == buyerID),
                SellerId = sellerID,
                Seller = _dataService.GetUsers.Single(u=>u.Id == sellerID),
                buyerCardsInfo = buyerTradedCards,
                sellerCardsInfo = sellerTradedCards,
                InitatedDate = DateTime.Now,
            };

            _dataService.AddEntity(trade);

            trade.buyerCardsInfo.ForEach(b=> {
                b.TradeId = trade.Id;
                b.Trade = trade;
                _dataService.AddEntity(b);

              
            });

            trade.sellerCardsInfo.ForEach(s =>
            {
                s.TradeId = trade.Id;
                s.Trade = trade;
                _dataService.AddEntity(s);

            });

            _dataService.SaveDatabaseChanges();
            return trade;
            

        }

       

        public AcceptTradeViewModel AcceptTrade(uint Id)
        {

            Trade trade = _dataService.GetTrades.Single(t => t.Id == Id);
            List<Card> recivedCards = new List<Card>();
            List<Card> tradedCards = new List<Card>();
            TradeUser Me = _dataService.GetUsers.Single(u => u.Id == trade.SellerId);

            trade.buyerCardsInfo.ForEach((b) =>
            {

                var Card = _dataService.GetCards.Single(c => c.Id == b.CardId);
                Card.OwnerID = trade.SellerId;
                Card.Owner = trade.Seller;
                Card.Available = true;
                _dataService.UpdateEntity(Card);
                recivedCards.Add(Card);

            });

            trade.sellerCardsInfo.ForEach(s =>
            {
                var Card = _dataService.GetCards.Single(c => c.Id == s.CardId);
                Card.OwnerID = trade.BuyerId;
                Card.Owner = trade.Buyer;
                Card.Available = true;
                _dataService.UpdateEntity(Card);
                tradedCards.Add(Card);
            });

            trade.IsAccepted = true;
            trade.IsComplete = true;
            trade.CompletedDate = DateTime.Now;
            _dataService.UpdateEntity(trade);
            _dataService.SaveDatabaseChanges();

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
            Trade trade = _dataService.GetTrades.Single(t => t.Id == Id);
            List<Card> rejectedCards = new List<Card>();
            TradeUser me = _dataService.GetUsers.Single(u => u.Id == trade.SellerId);

            trade.buyerCardsInfo.ForEach(s =>
            {
                var Card = _dataService.GetCards.Single(c => c.Id == s.CardId);
                rejectedCards.Add(Card);
            });

            trade.IsAccepted = false;
            trade.IsComplete = true;
            trade.CompletedDate= DateTime.Now;

            _dataService.UpdateEntity(trade);
            _dataService.SaveDatabaseChanges();

            RejectTradeViewModel vm = new RejectTradeViewModel()
            {
                Me = me,
                rejectedCards = rejectedCards.AsEnumerable(),
            };



            return vm;

        }
    }
}