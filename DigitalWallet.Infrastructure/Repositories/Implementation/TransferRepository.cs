using DigitalWallet.Domain.Domain.Entities;
using DigitalWallet.Domain.Repositories.Abstractions;
using DigitalWallet.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DigitalWallet.Infrastructure.Repositories.Implementation
{
    public class TransferRepository : ITransferRepository
    {
        private readonly AppDbContext _context;

        public TransferRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
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

        public async Task<List<Transfer>> FindSentTransfersByUserId(Guid userId, DateTime? minDate, DateTime? maxDate, int page, int pageSize)
        {
            var query = _context.Transfers
                .Where(t => t.SenderId == userId);

            if (minDate.HasValue)
            {
                Console.WriteLine("MinDate é: " + minDate.ToString());
                minDate = minDate.Value.ToUniversalTime();
                query = query.Where(t => t.Moment >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                Console.WriteLine("maxDate é: " + maxDate.ToString());
                maxDate = maxDate.Value.ToUniversalTime();
                query = query.Where(t => t.Moment <= maxDate.Value);
            }

            query = query
                .OrderByDescending(t => t.Moment)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return await query
            .Include(t => t.Sender)
            .Include(t => t.Receiver)
            .ToListAsync();
        }

        public async Task<List<Transfer>> GetTransfers(Guid userId, DateTime? minDate, DateTime? maxDate, int page, int pageSize)
        {
            var query = _context.Transfers
                        .Where(t => t.SenderId == userId || t.ReceiverId == userId);

            if (minDate.HasValue)
            {
                Console.WriteLine("MinDate é: " + minDate.ToString());
                minDate = minDate.Value.ToUniversalTime();
                query = query.Where(t => t.Moment >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                Console.WriteLine("maxDate é: " + maxDate.ToString());
                maxDate = maxDate.Value.ToUniversalTime();
                query = query.Where(t => t.Moment <= maxDate.Value);
            }

            query = query
                .OrderByDescending(t => t.Moment)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return await query
            .Include(t => t.Sender)
            .Include(t => t.Receiver)
            .ToListAsync();
        }
    }
}
