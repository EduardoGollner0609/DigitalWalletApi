using DigitalWalletApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalWalletApi.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        DbSet<User> Users { get; set; }
        DbSet<Transfer> Transfers { get; set; }
    }
}
