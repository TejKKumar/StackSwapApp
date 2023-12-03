using StackSwapApplication.Models.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

//By Tejas 
namespace StackSwapApplication.Models
{
    public class CatalogueItem 
    {
        //Fields 
        private string? _champion;
        private Tier _tier;
        private double _damage;
        private double _magic;
        private double _health;
        private uint _credits;
        private uint _id;
        
        /// <summary>
        /// Constructor for the catalogue item 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="champion"></param>
        /// <param name="tier"></param>
        /// <param name="damage"></param>
        /// <param name="magic"></param>
        /// <param name="health"></param>
        /// <param name="credits"></param>
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

        //Properties 
        public uint Id { get => _id; }
        public string? Champion { get => _champion; }
        public Tier Tier { get => _tier; }
        public double Damage { get => _damage; }
        public double Magic { get => _magic; }
        public double Health { get => _health; }
        public uint Credits { get => _credits;}
        
        
    }
}
