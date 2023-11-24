using StackSwapApplication.Models;
using StackSwapApplication.Services.DataServices;

namespace StackSwapApplication.Services
{
    public class CardRepository : ICardService
    {
        

        private IDataService _dataService;
        public CardRepository(IDataService dataService) 
        { 
            _dataService = dataService;
        
        }
        public IEnumerable<Card> GetAllCards()
        {
            return _dataService.GetCards.AsEnumerable();
        }

        public List<Card> GetCardByName(string name)
        {
            return _dataService.GetCards.Where(c=>c.Champion == name).ToList();
        }

        public List<Card> GetCardByTier(Tier tier)
        {
            return _dataService.GetCards.Where(c=>c.CardTier == tier).ToList(); 
        }

        public List<Card> GetCardByUserName(string userName)
        {
            return _dataService.GetCards.Where(c=>c.Owner.Username == userName).ToList();   
        }
    }
}
