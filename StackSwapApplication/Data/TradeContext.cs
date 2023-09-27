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

        public DbSet<User> Users { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }
    }
}
