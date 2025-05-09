using DigitalWalletApi.Domain.Abstractions;

namespace DigitalWalletApi.Infra.Repositories.Abstractions
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> CreateAsync(T entity);
    }
}
