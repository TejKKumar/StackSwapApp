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



        public IQueryable<User> GetUsers => _tradeContext.Users;

        public void AddEntity(BaseEntity entity)
        {
            
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));



            switch (entity)
            {
                case User u:
                    
                    _tradeContext.Users.Add(u);
                    break;
                    

            }
        }

        public void RemoveEntity(BaseEntity entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));

            switch(entity) 
            {
                case User u:
                    _tradeContext.Users.Remove(u);
                    break;
            
            }
        }

        public void UpdateEntity(BaseEntity entity)
        {
            if(entity == null)
                throw new ArgumentException(nameof(entity));

            switch (entity)
            {
                case User u:
                    _tradeContext.Users.Update(u);
                    break;
            }
        }
    }
}
