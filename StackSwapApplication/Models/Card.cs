using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using StackSwapApplication.Models.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace StackSwapApplication.Models
{
	public enum Tier {
		Tier1=1,
		Tier2=2,
		Tier3=3,
		Tier4=4,
		Tier5=5
	}
	public class Card : BaseEntity
	{
		private uint _cardId;
		private string? _champion;
		private Tier _tier;
		private double _damage;
		private double _magic;
		private double _health;
		private uint _ownerId;

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public override uint Id { get => _cardId; set => SetProperty(ref _cardId, value); }
		public uint GetCardId => _cardId;

		public string? Champion { get => _champion; set => _champion = value; }
		public Tier CardTier { get => _tier; set => SetProperty(ref _tier , value); }
		public double Damage { get => _damage; set => SetProperty(ref _damage, value); }
		public double Magic { get => _magic; set => SetProperty(ref _magic, value); }
		public double Health { get => _health; set => SetProperty(ref _health, value); }
		public uint OwnerID { get; set; }
		public TradeUser? Owner { get; set; }

        public void Change(Card c)
        {
            this.Champion = c.Champion;
            this.CardTier = c.CardTier;
            this.Damage = c.Damage;
            this.Magic = c.Magic;
            this.Health = c.Health;
            this.OwnerID = c.OwnerID;
            this.Owner = c.Owner;
        }


    }
}
