using StackSwapApplication.Models;
using StackSwapApplication.ViewModels;

namespace StackSwapApplication.Services
{
    public interface ITradeService
    {
        public Trade MakeTradeRequest(uint buyerID, uint sellerID, List<uint> buyerCardIDs, List<uint> sellerCardIDs);

        public AcceptTradeViewModel AcceptTrade(uint Id);
        public RejectTradeViewModel RejectTrade(uint Id);   
    }

}