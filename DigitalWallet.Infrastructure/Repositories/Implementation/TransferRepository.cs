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
    }
}
