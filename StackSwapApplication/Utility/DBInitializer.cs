﻿using StackSwapApplication.Data;
using StackSwapApplication.Models;

namespace StackSwapApplication.Utility
{
    public static class DBInitializer
    {
        public static void Initialize(TradeContext context)
        {
            if (context.Users.Any() &&
               context.Cards.Any())
            {
                foreach(var card in context.Cards) 
                {
                    card.Owner = context.Users.Single(u => u.Id == card.OwnerID);                                   
                }

                return;
            }

            TradeUser u1 = new TradeUser()
            {
                Name = "Deepthansu S",
                Email = "deepthansu@gmail.com",
                Password = "Password1",
                UserName = "DS",
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
                UserName = "RD",
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
