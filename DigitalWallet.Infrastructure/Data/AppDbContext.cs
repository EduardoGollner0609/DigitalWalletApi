using DigitalWallet.Domain.Domain.Entities;
using DigitalWallet.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DigitalWallet.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        DbSet<User> Users { get; set; }
        DbSet<Transfer> Transfers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TransferConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
