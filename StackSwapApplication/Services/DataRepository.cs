using StackSwapApplication.Data;
using StackSwapApplication.Models;
using StackSwapApplication.Models.BaseEntities;
using System.CodeDom;

namespace StackSwapApplication.Services
{
    //This class is meant for managing the data an will be added as transient in the services of the program 
    public class DataRepository : IDataService
    {

        public TradeContext _tradeContext;

        public DataRepository(TradeContext tradeContext)
        {
            _tradeContext = tradeContext;
        }

        public IQueryable<TradeUser> GetUsers => _tradeContext.Users;

        public IQueryable<Card> GetCards => _tradeContext.Cards;

        public virtual void AddEntity<T>(T entity) where T : BaseEntity
        {
            switch(entity) 
            {
                case TradeUser u:
                    _tradeContext.Users.Add(u);
                    break;
                case Card c:
                    _tradeContext.Cards.Add(c);
                    break;
                
            }

            _tradeContext.SaveChanges();
        }

     

        public virtual void RemoveEntity<T>(T entity) where T : BaseEntity
        {
            switch (entity)
            {
                case TradeUser u:
                    _tradeContext.Users.Remove(u);
                    break;
                case Card c:
                    _tradeContext.Cards.Remove(c);
                    break;

            }

            _tradeContext.SaveChanges();
        }

        public virtual void UpdateEntity<T>(T entity) where T : BaseEntity
        {
            switch (entity)
            {
                case TradeUser u:
                    {
                        TradeUser? user = _tradeContext.Users.Find(u.Id);
                        if (user != null)
                        {
                            user.Change(u);
                        }
                        break;
                    }
                case Card c:
                    {
                        Card? card = _tradeContext.Cards.Find(c.Id);
                        if (card != null)
                        {
                            card.Change(c);
                        }
                        break;
                    }

            }

            _tradeContext.SaveChanges();
        }
    }
}
