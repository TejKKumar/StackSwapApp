using Microsoft.EntityFrameworkCore;
using StackSwapApplication.Models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using StackSwapApplication.Utility;

//By Tejas 
namespace StackSwapApplication.Data
{
    public class TradeContext : DbContext
    {
        /// <summary>
        /// Constructor for TradeContext
        /// </summary>
        /// <param name="options"></param>
        public TradeContext(DbContextOptions<TradeContext> options) : base(options) 
        { 
            
        }

        //Db Sets for all critical entities/models 
        public DbSet<TradeUser> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Trade> Trades { get; set;}
        public DbSet<TradeBuyerCard> TradeBuyerCards { get; set; }
        public DbSet<TradeSellerCard> TradeSellerCards { get; set; }
        public DbSet<PurchaseCard> PurchaseCards { get; set; }


        //
        /// <summary>
        /// Overriden method used to map entites to each other and call an extension method for seeding data
        /// </summary>
        /// <param name="modelBuilder"></param>
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
                .WithOne(bc => bc.Trade)
                .HasForeignKey(bc => bc.TradeId);

                entity.HasMany(t => t.sellerCardsInfo)
                .WithOne(sc => sc.Trade)
                .HasForeignKey(sc => sc.TradeId);
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

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasMany(p => p.PurchaseCards)
                .WithOne(pc => pc.Purchase)
                .HasForeignKey(pc => pc.PurchaseId);
            });

            modelBuilder.Entity<PurchaseCard>(entity =>
            {
                entity.HasOne(pc => pc.Purchase)
                .WithMany(p => p.PurchaseCards)
                .HasForeignKey(pc => pc.PurchaseId);
            });

            modelBuilder.Seed();

            
        }
    }
}
