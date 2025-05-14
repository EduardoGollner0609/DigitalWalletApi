using DigitalWallet.Domain.Domain.Abstractions;

namespace DigitalWallet.Domain.Repositories.Abstractions
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> CreateAsync(T entity);
    }
}
