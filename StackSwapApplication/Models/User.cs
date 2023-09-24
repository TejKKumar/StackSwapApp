using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations.Schema;
using StackSwapApplication.Models.BaseEntities;

namespace StackSwapApplication.Models
{
    public class User : BaseEntity
    {
        private uint _id;
        private string _name;
        private string _email;
        private string _password;
        private string _userName;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override uint Id { get => _id; set => SetProperty(ref _id, value); }


        public uint GetId => _id;

        public string Name { get => _name; set= _name; }
        public string Email { get => _email; set = _email; }
        public string Password { get => _password; set = _password;}
        public string UserName { get => _userName; set = _userName;}






    }
}
