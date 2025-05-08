using DigitalWalletApi.Data;
using DigitalWalletApi.Domain.Entities;
using DigitalWalletApi.Infra.Repositories.Abstractions;

namespace DigitalWalletApi.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<User> CreateAsync(Task entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<User>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> FindById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
