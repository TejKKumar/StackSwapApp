using StackSwapApplication.Models;
using StackSwapApplication.Models.BaseEntities;

namespace StackSwapApplication.Services
{
    public interface IDataService
    {
        //public IQueryable<User> GetUsers { get; }

        public void AddEntity<T>(T entity) where T : BaseEntity;

        public void RemoveEntity<T>(T entity) where T : BaseEntity;

        public void UpdateEntity<T>(T entity) where T :BaseEntity;

        

        public IQueryable<TradeUser> GetUsers { get; }
        public IQueryable<Card> GetCards { get; }
    }
}
