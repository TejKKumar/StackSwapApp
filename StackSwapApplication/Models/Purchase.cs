using System.ComponentModel.DataAnnotations;

namespace StackSwapApplication.Models
{
    public class Purchase
    {
        [Key]
        public uint Id { get; set; }

        [Required]
        public TradeUser? Buyer { get; set; }

        [Required]
        public uint BuyerId { get; set; }   

        [Required]
        public List<PurchaseCard>? PurchaseCards { get; set; }

        [Required]
        public DateTime? PurchaseDate { get; set; }
    }
}
