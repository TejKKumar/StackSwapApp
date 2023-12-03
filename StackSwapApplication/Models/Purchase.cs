using StackSwapApplication.Models.BaseEntities;
using System.ComponentModel.DataAnnotations;

//By Imran 
namespace StackSwapApplication.Models
{
    public class Purchase : BaseEntity
    {
        //Properties 
        [Key]
        public override uint Id { get; set; }

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
