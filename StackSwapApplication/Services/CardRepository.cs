﻿using StackSwapApplication.Data;
using StackSwapApplication.Models;

namespace StackSwapApplication.Services
{
    public class CardRepository : ICardService
    {
        //public readonly TradeContext _tradeContext;

        //public CardRepository(TradeContext tradeContext)
        //{
        //    _tradeContext = tradeContext;
        //}

        //public IEnumerable<Card> GetAllCards()
        //{
        //    List<Card> cards = _tradeContext.Cards.ToList();
        //    return cards;
        //}

        //public List<Card> GetCardByName(string name)
        //{
        //    List<Card> cards = _tradeContext.Cards.Where(c=>c.Champion == name).ToList();
        //    return cards;
        //}

        //public List<Card> GetCardByTier(Tier tier)
        //{
        //    List<Card> card = _tradeContext.Cards.Where(c=>c.CardTier == tier).ToList();
        //    return card;
        //}

        //public List<Card> GetCardByUserName(string userName)
        //{
        //    throw new NotImplementedException();
        //}

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
