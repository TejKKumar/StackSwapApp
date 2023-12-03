using StackSwapApplication.Models.BaseEntities;
using System.ComponentModel.DataAnnotations;

//By Deepthanshu 
namespace StackSwapApplication.Models
{
    public class Trade : BaseEntity
    {

        [Key]
        public override uint Id { get; set; }

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
        public DateTime InitatedDate { get; set; }

        
        public DateTime? CompletedDate { get; set; }

        [Required]
        public bool IsAccepted { get; set; }

        [Required]
        public bool IsComplete { get; set; }

        
    }
}