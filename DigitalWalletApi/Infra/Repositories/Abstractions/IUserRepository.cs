using DigitalWalletApi.Domain.Entities;

namespace DigitalWalletApi.Infra.Repositories.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindByEmailAsync(string email);
    }
}
