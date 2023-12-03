using StackSwapApplication.Models;
using StackSwapApplication.Services.DataServices;

//By Rashesh 
namespace StackSwapApplication.Services
{
    public class CardRepository : ICardService
    {
        
        private IDataService _dataService;

        /// <summary>
        /// Constructor for CardRepository 
        /// </summary>
        /// <param name="dataService"></param>
        public CardRepository(IDataService dataService) 
        { 
            _dataService = dataService;
        
        }
        //
        /// <summary>
        /// Method for geting all cards 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Card> GetAllCards()
        {
            return _dataService.GetCards.AsEnumerable();
        }

        //
        /// <summary>
        /// Method for getting all cards with of a certain Champion 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Card> GetCardByName(string name)
        {
            return _dataService.GetCards.Where(c=>c.Champion == name).ToList();
        }

        //
        /// <summary>
        /// Method for getting all cards by a Tier
        /// </summary>
        /// <param name="tier"></param>
        /// <returns></returns>
        public List<Card> GetCardByTier(Tier tier)
        {
            return _dataService.GetCards.Where(c=>c.CardTier == tier).ToList(); 
        }

        //
        /// <summary>
        /// Method for getting all cards who belong to a user 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public List<Card> GetCardByUserName(string userName)
        {
            return _dataService.GetCards.Where(c=>c.Owner.Username == userName).ToList();   
        }
    }
}
