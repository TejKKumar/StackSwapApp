namespace StackSwapApplication.Models.BaseEntities
{
    public class BaseCatalogueItem : BaseEntity
    {
        private uint _id;

        public override uint Id { get => _id; set => _id = value; }


       

        public uint GetID => _id;
    }
}
