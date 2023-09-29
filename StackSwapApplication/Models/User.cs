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

        public string Name { get => _name; set=> SetProperty(ref _name, value); }
        public string Email { get => _email; set => SetProperty(ref _email, value); }
        public string Password { get => _password; set => SetProperty(ref _password, value); }
        public string UserName { get => _userName; set => SetProperty(ref _userName, value);}






    }
}
