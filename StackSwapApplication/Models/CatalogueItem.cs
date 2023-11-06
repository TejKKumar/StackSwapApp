namespace StackSwapApplication.Models
{
    public class CatalogueItem
    {
        private string _champion;
        private Tier _tier;
        private double _damage;
        private double _magic;
        private double _health;

        
        public CatalogueItem(string champion, Tier tier, double damage, double magic, double health)
        {
            _champion = champion;
            _tier = tier;
            _damage = damage;
            _magic = magic;
            _health = health;
        }

        public string GetChampion { get => _champion; }
        public Tier GetTier { get => _tier; }
        public double GetDamage { get => _damage; }
        public double GetMagic { get => _magic; }
        public double GetHealth { get => _health; }
    }
}
