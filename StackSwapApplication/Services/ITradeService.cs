using StackSwapApplication.Models;
using StackSwapApplication.ViewModels;

namespace StackSwapApplication.Services
{
    public interface ITradeService
    {
        public void MakeTrade(TradeUser Buyer, TradeUser Seller, List<Card> buyerCards, List<Card> sellerCards);
        public Trade MakeTradeRequest(uint buyerID, uint sellerID, List<uint> buyerCardIDs, List<uint> sellerCardIDs);

        public AcceptTradeViewModel AcceptTrade(uint Id);
        public RejectTradeViewModel RejectTrade(uint Id);   
    }

}