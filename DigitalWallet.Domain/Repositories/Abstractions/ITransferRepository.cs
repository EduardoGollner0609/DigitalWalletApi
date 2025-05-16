using DigitalWallet.Domain.Domain.Entities;

namespace DigitalWallet.Domain.Repositories.Abstractions
{
    public interface ITransferRepository : IRepository<Transfer>
    {
        Task<List<Transfer>> FindSentTransfersByUserId
            (Guid userId, DateTime? minDate, DateTime? maxDate, int page, int pageSize);
        Task<List<Transfer>> GetTransfers
            (Guid userId, DateTime? minDate, DateTime? maxDate, int page, int pageSize);
    }
}
