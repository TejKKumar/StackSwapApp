using StackSwapApplication.Models.BaseEntities;

//By Tejas
namespace StackSwapApplication.Models
{
    public class PurchaseCard : BaseEntity
    {
        private uint _id;

        public override uint Id { get => _id; set => _id = value; }
        public Purchase Purchase { get; set; }
        public virtual Card Card { get; set; }
        public uint PurchaseId { get; set; }
        public uint CardId { get; set; }
    }
}
