using DigitalWallet.Domain.Domain.Entities;
using DigitalWallet.Domain.Repositories.Abstractions;
using DigitalWallet.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
            await _context
                .Users
                .AddAsync(entity);

            await _context
                .SaveChangesAsync();
            return entity;
        }

        public async Task<bool> ExistsByEmail(string email)
        {
            return await _context
                .Users
                .AnyAsync(u => u.Email == email);
        }

        public async Task<bool> ExistsByIdAsync(Guid id)
        {
            return await _context
                .Users
                .AnyAsync(u => u.Id == id);
        }

        public async Task<User> FindByIdAsync(Guid id)
        {
            return await _context
                .Users
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _context
                .Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
