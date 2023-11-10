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



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>().ToTable("Cards");
            modelBuilder.Entity<TradeUser>().ToTable("Users");


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

            });

        }
    }
}
