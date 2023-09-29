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
		private string _champion;
		private uint _championId;
		private Tier _tier;
		private double _damage;
		private double _magic;
		private double _health;

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public override uint Id { get => _cardId; set => SetProperty(ref _cardId, value); }
		public uint GetCardId => _cardId;

		public string GetChampion => _champion;

		public uint CardId { get => _cardId; set => _cardId = value; }
		public string Champion { get => _champion; set => _champion = value; }
		public uint ChampionId { get => _championId; set => _championId = value; }
		public Tier Tier { get => _tier; set => _tier = value; }
		public double Damage { get => _damage; set => SetProperty(ref _damage, value); }
		public double Magic { get => _magic; set => SetProperty(ref _magic, value); }
		public double Health { get => _health; set => SetProperty(ref _health, value); }

		
	}
}
