using StackSwapApplication.Models;
using System.ComponentModel.DataAnnotations;
using StackSwapApplication.Utility;

namespace StackSwapApplication.ViewModels
{
    public class ViewCardsVM
    {

        
        public TradeUser Buyer { get; set; }
    
        public List<CardCheckBox> BuyerCards {  get; set; } = new List<CardCheckBox>();

        //public IEnumerable<CardCheckBox> BCards { get; set; }
        

        public TradeUser Seller { get; set; }

        
        public List<CardCheckBox> SellerCards { get; set; } = new List<CardCheckBox>(); 
        //public IEnumerable<CardCheckBox> SCards { get; set; }   
    }
}
