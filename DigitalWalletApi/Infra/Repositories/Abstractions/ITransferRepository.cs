using DigitalWalletApi.Domain.Entities;

namespace DigitalWalletApi.Infra.Repositories.Abstractions
{
    public interface ITransferRepository : IRepository<Transfer>
    {
        Task<List<Transfer>> GetSentTransfersByDateAsync(Guid senderId, DateTime? minDate, DateTime? maxDate);
    }
}
