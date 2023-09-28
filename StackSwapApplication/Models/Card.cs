using StackSwapApplication.Models.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace StackSwapApplication.Models
{
	public class Card : BaseEntity
	{
		private uint _cardId;
		private string _champion;
		private uint _championId;
		private string _tier;
		private double _damage;
		private double _magic;
		private double _health;

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public override uint Id { get => _cardId; set => SetProperty(ref _cardId, value); }
		public uint GetCardId () { return _cardId; }

		public string GetChampion => _champion;
		public void SetChampion(string champion) => _champion = champion;

		public uint GetChampionId => _championId;

		public string GetTier => _tier;

		public void SetTier(string tier) => _tier = tier;	

		public double GetDamage => _damage;

		public void SetDamage(double damage) => _damage = damage;
		public double GetMagic => _magic;
		
		public void SetMagic(double magic) => _magic = magic;	

		public double GetHealth => _health;

		public void SetHealth(double health) => _health = health;
	}
}
