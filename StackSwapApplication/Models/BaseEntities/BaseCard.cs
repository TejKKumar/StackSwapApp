using System.ComponentModel.DataAnnotations.Schema;

namespace StackSwapApplication.Models.BaseEntities
{
    public class BaseCard : BaseEntity
    {
        private uint _id;
       

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override uint Id { get => _id; set => _id = value; }


        
       

        public uint GetID => _id;
    }

}
