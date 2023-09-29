using System.ComponentModel.DataAnnotations.Schema;

namespace StackSwapApplication.Models.BaseEntities
{
    public class BaseCatalogueItem : BaseEntity
    {
        private uint _id;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override uint Id { get => _id; set => SetProperty(ref _id, value); }


       

        public uint GetID => _id;

    }

}
