using StackSwapApplication.Models.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackSwapApplication.Models
{
    public class CatalogueItem 
    {
        private string _champion;
        private Tier _tier;
        private double _damage;
        private double _magic;
        private double _health;
        private uint _credits;
        private uint _id;

        
        public CatalogueItem(uint id,string champion, Tier tier, double damage, double magic, double health, uint credits)
        {
            _id = id;   
            _champion = champion;
            _tier = tier;
            _damage = damage;
            _magic = magic;
            _health = health;
            _credits = credits;

        }


        public string GetChampion { get => _champion; }
        public Tier GetTier { get => _tier; }
        public double GetDamage { get => _damage; }
        public double GetMagic { get => _magic; }
        public double GetHealth { get => _health; }
        public uint GetCredits { get => _credits;}
        public uint GetId { get => _id; }
        
        
    }
}
