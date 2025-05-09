using DigitalWalletApi.Data;
using DigitalWalletApi.Domain.Entities;
using DigitalWalletApi.Infra.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DigitalWalletApi.Infra.Repositories.Implementation
{
    public class TransferRepository : ITransferRepository
    {

        private readonly AppDbContext _context;

        public TransferRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Transfer> CreateAsync(Transfer entity)
        {
            await _context.Transfers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return await _context.Transfers
                .Include(t => t.Sender)
                .Include(t => t.Receiver)
                .FirstOrDefaultAsync(t => t.Id == entity.Id);
        }

        public async Task<List<Transfer>> GetSentTransfersByDateAsync(Guid senderId, DateTime? minDate, DateTime? maxDate)
        {
            var query = _context.Transfers
                .Where(t => t.SenderId == senderId);

            if (minDate != null)
            {
                minDate = minDate.Value.ToUniversalTime();
                Console.WriteLine("Data min em utc: " + minDate);
                query = query.Where(t => t.Moment >= minDate.Value);
            }

            if (maxDate != null)
            {
                maxDate = maxDate.Value.ToUniversalTime();
                Console.WriteLine("Data max em utc: " + maxDate);
                query = query.Where(t => t.Moment <= maxDate.Value);
            }

            return await query
            .Include(t => t.Sender)
            .Include(t => t.Receiver)
            .ToListAsync();
        }
    }
}
