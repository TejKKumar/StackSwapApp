namespace StackSwapApplication.Models.BaseEntities
{
    public class BaseCatalogueItem : BaseEntity
    {
        private uint _id;

        public override uint Id { get => _id; set => _id = value; }


        public uint CardID { get; set; }
        public virtual BaseCard Card { get; set; }

        public uint GetID => _id;
    }
}
