using DigitalWalletApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalWalletApi.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
    }
}
