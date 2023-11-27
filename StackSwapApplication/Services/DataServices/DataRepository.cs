using Microsoft.EntityFrameworkCore;
using StackSwapApplication.Data;
using StackSwapApplication.Models;
using StackSwapApplication.Models.BaseEntities;
using StackSwapApplication.Utility;
using System.CodeDom;

//Created by Tejas Kumar
namespace StackSwapApplication.Services.DataServices
{
    //This class is meant for managing the data an will be added as transient in the services of the program 
    public class DataRepository : IDataService
    {
        /// <summary>
        /// Private reference that will be used to get TradeContext functions
        /// </summary>
        private TradeContext _tradeContext;


        /// <summary>
        /// Constructor for the DataRepository class which uses constructor injection to add TradeContext dependency.
        /// </summary>
        /// <param name="tradeContext"></param>
        public DataRepository(TradeContext tradeContext)
        {
            _tradeContext = tradeContext;
            DBInitializer.Initialize(_tradeContext);
        }

        /// <summary>
        /// Public collection for getting data. This collection of IQueryable to improve performance. 
        /// </summary>
        public IQueryable<TradeUser> GetUsers => _tradeContext.Users;

        public TradeUser GetUserByUsername(string username) => _tradeContext.Users.FirstOrDefault(u => u.Username == username);

        public IQueryable<Card> GetCards => _tradeContext.Cards;

        public IQueryable<Trade> GetTrades => _tradeContext.Trades;

        public IQueryable<Purchase> GetPurchases => _tradeContext.Purchases;

        public IQueryable<TradeBuyerCard> GetTradesBuyerCards => _tradeContext.TradeBuyerCards;

        public IQueryable<TradeSellerCard> GetTradesSellerCards => _tradeContext.TradeSellerCards;

        public IQueryable<PurchaseCard> GetPurchaseCards => _tradeContext.PurchaseCards;

        public virtual void AddEntity<T>(T entity) where T : BaseEntity
        {
            switch (entity)
            {
                case TradeUser u:
                    _tradeContext.Users.Add(u);
                    break;
                case Card c:
                    _tradeContext.Cards.Add(c);
                    break;
                case Trade t:
                    _tradeContext.Trades.Add(t);
                    break;
                case Purchase p:
                    _tradeContext.Purchases.Add(p);
                    break;
                case TradeBuyerCard buyerCard:
                    _tradeContext.TradeBuyerCards.Add(buyerCard);
                    break;
                case TradeSellerCard sellerCard:
                    _tradeContext.TradeSellerCards.Add(sellerCard);
                    break;
                case PurchaseCard purchaseCard:
                    _tradeContext.PurchaseCards.Add(purchaseCard);
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
                case Trade t:
                    _tradeContext.Trades.Remove(t);
                    break;
                case Purchase p:
                    _tradeContext.Purchases.Remove(p);
                    break;
                case TradeBuyerCard buyerCard:
                    _tradeContext.TradeBuyerCards.Remove(buyerCard);
                    break;
                case TradeSellerCard sellerCard:
                    _tradeContext.TradeSellerCards.Remove(sellerCard);
                    break;
                case PurchaseCard purchaseCard:
                    _tradeContext.PurchaseCards.Remove(purchaseCard);
                    break;

            }

            _tradeContext.SaveChanges();
        }

        public void SaveDatabaseChanges()
        {
            _tradeContext.SaveChanges();
        }

        public virtual void UpdateEntity<T>(T entity) where T : BaseEntity
        {
            switch (entity)
            {
                case TradeUser u:
                    {
                        _tradeContext.Update(u);
                        break;

                    }
                case Card c:
                    {
                        _tradeContext.Update(c);
                        break;
                    }
                case Trade t:
                    _tradeContext.Trades.Update(t);
                    break;
                case Purchase p:
                    _tradeContext.Purchases.Update(p);
                    break;
                case TradeBuyerCard buyerCard:
                    _tradeContext.TradeBuyerCards.Update(buyerCard);
                    break;
                case TradeSellerCard sellerCard:
                    _tradeContext.TradeSellerCards.Update(sellerCard);
                    break;
                case PurchaseCard purchaseCard:
                    _tradeContext.PurchaseCards.Update(purchaseCard);
                    break;

            }

            _tradeContext.SaveChanges();
        }
    }
}
