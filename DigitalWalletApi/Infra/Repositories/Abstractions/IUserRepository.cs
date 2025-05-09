using DigitalWalletApi.Domain.Entities;

namespace DigitalWalletApi.Infra.Repositories.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindByEmailAsync(string email);
        Task<bool> ExistsByEmailAsync(string email);
        Task<User> UpdateAsync(User user);
    }

}
