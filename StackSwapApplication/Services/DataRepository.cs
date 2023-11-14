﻿using StackSwapApplication.Data;
using StackSwapApplication.Models;
using StackSwapApplication.Models.BaseEntities;
using StackSwapApplication.Utility;
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
            DBInitializer.Initialize(_tradeContext);
        }

        public IQueryable<TradeUser> GetUsers => _tradeContext.Users;

        public IQueryable<Card> GetCards => _tradeContext.Cards;

        public IQueryable<Trade> GetTrades => _tradeContext.Trades;

        public IQueryable<Purchase> GetPurchases => _tradeContext.Purchases;

        public IQueryable<TradeBuyerCard> GetTradesBuyerCards => _tradeContext.TradeBuyerCards;

        public IQueryable<TradeSellerCard> GetTradesSellerCards => _tradeContext.TradeSellerCards;

        public IQueryable<PurchaseCard> GetPurchaseCards => _tradeContext.PurchaseCards;

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

            //_tradeContext.SaveChanges();
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

            //_tradeContext.SaveChanges();
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

            //_tradeContext.SaveChanges();
        }
    }
}
