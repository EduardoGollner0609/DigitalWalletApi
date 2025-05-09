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

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _context.Users
               .FirstOrDefaultAsync(
                u => u.Email == email
                );
        }

        public async Task<User> FindByIdAsync(Guid id)
        {
            return await _context.Users.
                FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
