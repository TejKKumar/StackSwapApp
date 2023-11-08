using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations.Schema;
using StackSwapApplication.Models.BaseEntities;

namespace StackSwapApplication.Models
{
    public class TradeUser : BaseEntity
    {
        private uint _id;
        private string _name;
        private string _email;
        private string _password;
        private string _userName;
        private uint _credits;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override uint Id { get => _id; set => SetProperty(ref _id, value); }


        public uint GetId => _id;

        public string Name { get => _name; set=> SetProperty(ref _name, value); }
        public string Email { get => _email; set => SetProperty(ref _email, value); }
        public string Password { get => _password; set => SetProperty(ref _password, value); }
        public string UserName { get => _userName; set => SetProperty(ref _userName, value);}
        public uint Credits { get => _credits; set => SetProperty(ref _credits, value); }
        public List<Card>? Cards { get; set; }


        public void Change(TradeUser user)
        {
            this.Name = user.Name;
            this.Email = user.Email;
            this.Password = user.Password;
            this.UserName = user.UserName;
            this.Cards = user.Cards;
            this.Credits = user.Credits;
        }  



    }
}
