using StackSwapApplication.Models;

namespace StackSwapApplication.Services
{
    public interface ICardService
    {
        public IEnumerable<Card> GetAllCards();

        public List<Card> GetCardByUserName(string userName);

       // public Card GetCardByTier(string userName);
        public List<Card> GetCardByName(string name); //cardname

        
    }

}
