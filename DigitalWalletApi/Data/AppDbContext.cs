using Microsoft.EntityFrameworkCore;

namespace DigitalWalletApi.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
    }
}
