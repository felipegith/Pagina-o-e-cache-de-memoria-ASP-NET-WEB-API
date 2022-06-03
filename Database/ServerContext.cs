using ECONOMY.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECONOMY.API.Database
{
    public class ServerContext : DbContext
    {
        public ServerContext(DbContextOptions<ServerContext> options) : base(options)
        {

        }

        public DbSet<Balance> Balances { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Balance>(e =>
            {
                e.HasMany(e => e.Accounts).WithOne().HasForeignKey(e => e.IdBalance);
            });
        }
    }
}
