using System.ComponentModel.DataAnnotations;

namespace StackSwapApplication.Models
{
    public class Trade
    {

        [Key]
        public uint Id { get; set; }

        [Required]
        public TradeUser? Seller { get; set; }

        [Required]  
        public uint SellerId {  get; set; } 

        [Required]
        public TradeUser? Buyer { get; set; }

        [Required]
        public uint BuyerId { get; set; }

        //[Required]
        //public List<Card>? sellerCards { get; set; }

        //[Required]
        //public List<Card>? buyerCards { get; set; }

        [Required]
        public List<TradeBuyerCard> buyerCardsInfo { get; set; }

        [Required]
        public List<TradeSellerCard> sellerCardsInfo { get; set;}

  
        [Required]
        public DateTime? TradeDate { get; set; }

        [Required]
        public bool IsAccepted { get; set; }

        [Required]
        public bool IsComplete { get; set; }

        
    }
}