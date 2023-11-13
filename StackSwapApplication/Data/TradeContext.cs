using Microsoft.EntityFrameworkCore;
using StackSwapApplication.Models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace StackSwapApplication.Data
{
    public class TradeContext : DbContext
    {
        public TradeContext(DbContextOptions<TradeContext> options) : base(options) 
        { 
            
        }

        public DbSet<TradeUser> Users { get; set; }

        public DbSet<Card> Cards { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Trade> Trades { get; set;}

        public DbSet<TradeBuyerCard> TradeBuyerCards { get; set; }
        public DbSet<TradeSellerCard> TradeSellerCards { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>().ToTable("Cards");
            modelBuilder.Entity<TradeUser>().ToTable("Users");
            modelBuilder.Entity<Trade>().ToTable("Trades");
            modelBuilder.Entity<Purchase>().ToTable("Purchases");
            modelBuilder.Entity<TradeBuyerCard>().ToTable("TradeBuyerCards");
            modelBuilder.Entity<TradeSellerCard>().ToTable("TradeSellerCards");


            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasOne(c => c.Owner)
                .WithMany(o => o.Cards)
                .HasForeignKey(o => o.OwnerID);
            });

            modelBuilder.Entity<TradeUser>(entity =>
            {
                entity.HasMany(u => u.Cards)
                .WithOne(c => c.Owner)
                .HasForeignKey(c => c.OwnerID);

                entity.HasMany(u => u.Purchases)
                .WithOne(p => p.Buyer)
                .HasForeignKey(p => p.BuyerId);

                entity.HasMany(u => u.Trades)
                .WithOne(t => t.Buyer)
                .HasForeignKey(t => t.BuyerId);

            });

            modelBuilder.Entity<Trade>(entity =>
            {
                entity.HasMany(t => t.buyerCardsInfo)
                .WithOne(b => b.Trade)
                .HasForeignKey(b => b.TradeId);
            });

            modelBuilder.Entity<Trade>(entity =>
            {
                entity.HasMany(t => t.sellerCardsInfo)
                .WithOne(s => s.Trade)
                .HasForeignKey(s => s.TradeId);
            });

            modelBuilder.Entity<TradeBuyerCard>(entity =>
            {
                entity.HasOne(t => t.Trade)
                .WithMany(t => t.buyerCardsInfo)
                .HasForeignKey(t => t.TradeId);
 
            });

            modelBuilder.Entity<TradeSellerCard>(entity =>
            {
                entity.HasOne(t => t.Trade)
                .WithMany(t => t.sellerCardsInfo)
                .HasForeignKey(t => t.TradeId);

            });
        }
    }
}
