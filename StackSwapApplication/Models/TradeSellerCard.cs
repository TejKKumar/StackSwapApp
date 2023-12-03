using StackSwapApplication.Models.BaseEntities;

//By Tejas 
namespace StackSwapApplication.Models
{
    public class TradeSellerCard : BaseEntity
    {
        private uint _id;
        public override uint Id { get => _id; set => _id = value; }

        public uint TradeId;
        public Trade Trade { get; set; }
        public uint SellerId { get; set; }
        public virtual Card Card { get; set; }
        public uint CardId { get; set; }
    }
}
