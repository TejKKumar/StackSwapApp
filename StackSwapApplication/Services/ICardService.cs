using StackSwapApplication.Models;

namespace StackSwapApplication.Services
{
    public interface ICardService
    {
        public IEnumerable<Card> GetAllCards();

        public List<Card> GetCardByUserName(string userName);

        public List<Card> GetCardByTier(Tier tier);
        public List<Card> GetCardByName(string name); //cardname

        
    }

}
