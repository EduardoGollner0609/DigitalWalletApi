using DigitalWallet.Domain.Domain.Entities;
using DigitalWallet.Domain.Repositories.Abstractions;
using DigitalWallet.Infrastructure.Data;

namespace DigitalWallet.Infrastructure.Repositories.Implementation
{
    internal class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<User> CreateAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
