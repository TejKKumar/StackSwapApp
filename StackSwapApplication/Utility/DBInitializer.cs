using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using StackSwapApplication.Data;
using StackSwapApplication.Models;

namespace StackSwapApplication.Utility
{
    public static class DBInitializer
    {

        public static void Seed(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<TradeUser>().HasData(
                new TradeUser() { Id = 1, Name = "Ben Gorthy", Username = "Dovaquila", Password = "beng1", Credits = 2755, Email = "bgorthy@gmail.com" },
                new TradeUser() { Id = 2, Name = "Nafee Kamal", Username = "Zangun", Password = "nKamal2", Credits = 1500, Email = "nKamal@gmail.com" },
                new TradeUser() { Id = 3, Name = "Jennifer Hunter", Username = "VioletJen", Password = "jHunter3", Credits = 5500, Email = "jhunter@gmail.com" },
                new TradeUser() { Id = 4, Name = "Joyce Yang", Username = "JuicyJ", Password = "jYang5", Credits = 500, Email = "jyang@gmail.com" },
                new TradeUser() { Id = 5, Name = "Jenny Nguyen", Username = "J-Wizzy", Password = "jjNguy", Credits = 5500, Email = "jnguyen@gmail.com" },
                new TradeUser() { Id = 6, Name = "Johnathan Graham", Username = "JonJonQ", Password = "jGraham2", Credits = 17500, Email = "jjohng@gmail.com" },
                new TradeUser() { Id = 7, Name = "Umair Shazad", Username = "BigRick", Password = "umRick22", Credits = 175, Email = "shazadU@gmail.com" },
                new TradeUser() { Id = 8, Name = "Shannon Gangnon", Username = "Shananigans", Password = "sh559", Credits = 350, Email = "sgangnon@gmail.com" },
                new TradeUser() { Id = 9, Name = "Mia Cia", Username = "CiayteMi", Password = "miaCy55", Credits = 1255, Email = "miaCIA@gmail.com" }
            );

            modelBuilder.Entity<Card>().HasData(
                new Card() { Id = 1, Champion = "Ashe", OwnerID = 1, CardTier = Tier.Tier1, Damage = 1250, Health = 800, Magic = 1500 },
                new Card() { Id = 2, Champion = "Ashe", OwnerID = 1, CardTier = Tier.Tier2, Damage = 1300, Health = 850, Magic = 1550 },
                new Card() { Id = 3, Champion = "Draven", OwnerID = 1, CardTier = Tier.Tier1, Damage = 3550, Health = 2800, Magic = 500 },
                new Card() { Id = 4, Champion = "Urgot", OwnerID = 1, CardTier = Tier.Tier5, Damage = 5250, Health = 900, Magic = 7500 },

                new Card() { Id = 5, Champion = "Draven", OwnerID = 2, CardTier = Tier.Tier5, Damage = 4025, Health = 5800, Magic = 2500 },
                new Card() { Id = 6, Champion = "Jarvan", OwnerID = 2, CardTier = Tier.Tier2, Damage = 3200, Health = 2800, Magic = 4500 },

                new Card() { Id = 7, Champion = "Ashe", OwnerID = 3, CardTier = Tier.Tier2, Damage = 1300, Health = 850, Magic = 1550 },

                new Card() { Id = 8, Champion = "Jax", OwnerID = 4, CardTier = Tier.Tier5, Damage = 1300, Health = 1850, Magic = 4550 },
                new Card() { Id = 9, Champion = "Olaf", OwnerID = 4, CardTier = Tier.Tier4, Damage = 6550, Health = 3800, Magic = 500 },
                new Card() { Id = 10, Champion = "Tarin", OwnerID = 4, CardTier = Tier.Tier4, Damage = 1250, Health = 1900, Magic = 7500 },

                new Card() { Id = 11, Champion = "Jax", OwnerID = 5, CardTier = Tier.Tier5, Damage = 1300, Health = 1850, Magic = 4550 },
                new Card() { Id = 12, Champion = "Draven", OwnerID = 5, CardTier = Tier.Tier1, Damage = 3550, Health = 2800, Magic = 500 },

                new Card() { Id = 13, Champion = "Jarvan", OwnerID = 6, CardTier = Tier.Tier2, Damage = 3200, Health = 2800, Magic = 4500 },
                new Card() { Id = 14, Champion = "Ashe", OwnerID = 6, CardTier = Tier.Tier2, Damage = 1300, Health = 850, Magic = 1550 },

                new Card() { Id = 15, Champion = "Jax", OwnerID = 7, CardTier = Tier.Tier5, Damage = 1300, Health = 1850, Magic = 4550 },
                new Card() { Id = 16, Champion = "Olaf", OwnerID = 7, CardTier = Tier.Tier4, Damage = 6550, Health = 3800, Magic = 500 },
                new Card() { Id = 17, Champion = "Tarin", OwnerID = 7, CardTier = Tier.Tier4, Damage = 1250, Health = 1900, Magic = 7500 },
                new Card() { Id = 18, Champion = "Jax", OwnerID = 7, CardTier = Tier.Tier5, Damage = 1300, Health = 1850, Magic = 4550 },
                new Card() { Id = 19, Champion = "Draven", OwnerID = 7, CardTier = Tier.Tier1, Damage = 3550, Health = 2800, Magic = 500 },

                new Card() { Id = 20, Champion = "Darius", OwnerID = 8, CardTier = Tier.Tier5, Damage = 7300, Health = 2850, Magic = 750 },
                new Card() { Id = 21, Champion = "A", OwnerID = 8, CardTier = Tier.Tier4, Damage = 550, Health = 7800, Magic = 3500 },

                new Card() { Id = 22, Champion = "Olaf", OwnerID = 9, CardTier = Tier.Tier4, Damage = 6550, Health = 3800, Magic = 500 },
                new Card() { Id = 23, Champion = "Tarin", OwnerID = 9, CardTier = Tier.Tier4, Damage = 1250, Health = 1900, Magic = 7500 },
                new Card() { Id = 24, Champion = "Jax", OwnerID = 9, CardTier = Tier.Tier5, Damage = 1300, Health = 1850, Magic = 4550 }
            );
            
            //This is one trade: User 7 traded with User 9 where User 7 traded 23, 24 for User 9's Card 15
            modelBuilder.Entity<Trade>().HasData(

                    new Trade() { Id=1,BuyerId = 7, SellerId = 9, TradeDate = new DateTime(2023, 7, 12, 22, 20, 4), IsAccepted=true, IsComplete=true }
                    );
            modelBuilder.Entity<TradeBuyerCard>().HasData(
                    new TradeBuyerCard() { Id=1,BuyerId = 7, CardId = 24, TradeId = 1 },
                    new TradeBuyerCard() { Id=2,BuyerId = 7, CardId = 23, TradeId = 1 }

                    );
            modelBuilder.Entity<TradeSellerCard>().HasData(
                    new TradeSellerCard() { Id=1,SellerId = 9, CardId = 15, TradeId = 1}
                );

            //This is one Purchase 
            modelBuilder.Entity<Purchase>().HasData(

                new Purchase() { Id=1,BuyerId=5, PurchaseDate = new DateTime(2020, 5, 1, 13, 30, 0) });
            modelBuilder.Entity<PurchaseCard>().HasData(

                new PurchaseCard() {Id=1, CardId=11, PurchaseId=1 }
                );

        }



        public static void Initialize(TradeContext context)
        {
            if (context.Users.Any() &&
               context.Cards.Any() 
              )
            {
                foreach(var card in context.Cards) 
                {
                    card.Owner = context.Users.Single(u => u.Id == card.OwnerID);                                   
                }

                if (context.Trades.Any() &&
               context.TradeBuyerCards.Any() &&
               context.TradeSellerCards.Any())
                {
                    foreach (var trade in context.Trades)
                    {
                        trade.Buyer = context.Users.Single(u => u.Id == trade.BuyerId);
                        trade.Seller = context.Users.Single(u => u.Id == trade.SellerId);
                    }
                    foreach (var tradeB in context.TradeBuyerCards)
                    {
                        tradeB.Trade = context.Trades.Single(t => t.Id == tradeB.TradeId);

                    }
                    foreach (var tradeS in context.TradeSellerCards)
                    {
                        tradeS.Trade = context.Trades.Single(t => t.Id == tradeS.TradeId);
                    }
                    
                }

                if (context.Purchases.Any() &&
               context.PurchaseCards.Any())
                {
                    foreach (var purchase in context.Purchases)
                    {
                        purchase.Buyer = context.Users.Single(u => u.Id == purchase.BuyerId);


                    }
                    foreach (var purchaseCard in context.PurchaseCards)
                    {
                        purchaseCard.Purchase = context.Purchases.Single(p => p.Id == purchaseCard.PurchaseId);
                    }
                }
             

                return;
            }

            TradeUser u1 = new TradeUser()
            {
                Name = "Deepthansu S",
                Email = "deepthansu@gmail.com",
                Password = "Password1",
                Username = "DS",
                Credits = 600,
                Cards = new List<Card>()
                {
                    new Card()
                    {
                        Champion = "Vagar",
                        CardTier = Tier.Tier2,
                        Damage = 230,
                        Magic = 500,
                        Health = 700,
                        
                        
                    },
                     new Card()
                    {
                        Champion = "Lala",
                        CardTier = Tier.Tier5,
                        Damage = 890,
                        Magic = 1500,
                        Health = 700,

                    },
                        new Card()
                    {
                        Champion = "Vuvu",
                        CardTier = Tier.Tier2,
                        Damage = 890,
                        Magic = 1500,
                        Health = 700,

                    }

                }
            };

            TradeUser u2 = new TradeUser()
            {
                Name = "Rasheesh D",
                Email = "rasheesh@gmail.com",
                Password = "Password2",
                Username = "RD",
                Credits = 575,
                Cards = new List<Card>()
                {
                    new Card()
                    {
                        Champion = "BoBo",
                        CardTier = Tier.Tier2,
                        Damage = 230,
                        Magic = 500,
                        Health = 700,

                    },
                     new Card()
                    {
                        Champion = "Ragnar",
                        CardTier = Tier.Tier5,
                        Damage = 890,
                        Magic = 1500,
                        Health = 700,

                    },
                        new Card()
                    {
                        Champion = "Vuvu",
                        CardTier = Tier.Tier2,
                        Damage = 890,
                        Magic = 1500,
                        Health = 700,

                    }

                }
            };

            context.Users.Add(u1);
            context.Users.Add(u2);

      //      context.SaveChanges();

            u1.Cards.ForEach(c => {
                c.OwnerID = u1.Id;
                c.Owner = u1;
                context.Cards.Add(c);
            });
            u2.Cards.ForEach(c=> 
            {
                c.OwnerID = u2.Id;
                c.Owner = u2;
                context.Cards.Add(c);
            });

         

            context.SaveChanges();

        }
    }
}
