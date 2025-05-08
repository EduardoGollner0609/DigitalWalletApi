using DigitalWalletApi.Data;
using DigitalWalletApi.Domain.Entities;
using DigitalWalletApi.Infra.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DigitalWalletApi.Infra.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<User>> FindAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _context.Users
               .FirstOrDefaultAsync(
                u => string.Equals(u.Email, email, StringComparison.CurrentCultureIgnoreCase)
                );
        }

        public async Task<User> FindByIdAsync(Guid id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
