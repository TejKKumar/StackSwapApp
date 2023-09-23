using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations.Schema;
using StackSwapApplication.Models.BaseEntities;

namespace StackSwapApplication.Models
{
    public class User : BaseEntity
    {
        private uint _id;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override uint Id { get => _id; set => SetProperty(ref _id, value); }


        public uint GetId => _id;




    }
}
