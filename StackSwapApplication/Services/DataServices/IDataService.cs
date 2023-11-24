using StackSwapApplication.Models;
using StackSwapApplication.Models.BaseEntities;

//Created by Tejas Kumar
namespace StackSwapApplication.Services.DataServices
{
    /// <summary>
    /// Interface that abstracts out the DataRepository 
    /// </summary>
    public interface IDataService
    {


        public void AddEntity<T>(T entity) where T : BaseEntity;

        public void RemoveEntity<T>(T entity) where T : BaseEntity;

        public void UpdateEntity<T>(T entity) where T : BaseEntity;

        public void SaveDatabaseChanges();



        public IQueryable<TradeUser> GetUsers { get; }
        public IQueryable<Card> GetCards { get; }
        public IQueryable<Trade> GetTrades { get; }
        public IQueryable<Purchase> GetPurchases { get; }
        public IQueryable<TradeBuyerCard> GetTradesBuyerCards { get; }
        public IQueryable<TradeSellerCard> GetTradesSellerCards { get; }
        public IQueryable<PurchaseCard> GetPurchaseCards { get; }
    }
}
