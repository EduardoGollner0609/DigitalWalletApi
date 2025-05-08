using DigitalWalletApi.Domain.Abstractions;

namespace DigitalWalletApi.Infra.Repositories.Abstractions
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> CreateAsync(Task entity);
        Task<ICollection<T>> FindAll();
        Task<T> FindById(Guid id);
    }
}
