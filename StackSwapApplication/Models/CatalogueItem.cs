using StackSwapApplication.Models.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackSwapApplication.Models
{
    public class CatalogueItem 
    {
        private string? _champion;
        private Tier _tier;
        private double _damage;
        private double _magic;
        private double _health;
        private uint _credits;
        private uint _id;
        
        public CatalogueItem(uint id, string champion, Tier tier, double damage, double magic, double health, uint credits)
        {
            _id = id;   
            _champion = champion;
            _tier = tier;
            _damage = damage;
            _magic = magic;
            _health = health;
            _credits = credits;
        }


        public uint Id { get => _id; }
        public string? Champion { get => _champion; }
        public Tier Tier { get => _tier; }
        public double Damage { get => _damage; }
        public double Magic { get => _magic; }
        public double Health { get => _health; }
        public uint Credits { get => _credits;}
        
        
    }
}
