using DigitalWallet.Domain.Domain.Entities;

namespace DigitalWallet.Domain.Repositories.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> ExistsByEmail(string email);
        Task<User> FindById(Guid id);
        Task<bool> ExistsById(Guid id);
    }
}
