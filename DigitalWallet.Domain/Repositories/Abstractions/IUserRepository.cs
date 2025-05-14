using DigitalWallet.Domain.Domain.Entities;

namespace DigitalWallet.Domain.Repositories.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> ExistsByEmail(string email);
        Task<User> FindByIdAsync(Guid id);
        Task<bool> ExistsByIdAsync(Guid id);
        Task<User> FindByEmailAsync(string email);
    }
}
