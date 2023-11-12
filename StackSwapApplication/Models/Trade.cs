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
        public TradeUser? Buyer { get; set; }

        [Required]
        public List<Card>? SellerCards { get; set; }

        [Required]
        public List<Card>? BuyerCards { get; set; }

        [Required]
        public DateTime? TradeDate { get; set; }

        
    }
}