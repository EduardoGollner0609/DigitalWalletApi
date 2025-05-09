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
            return await _context.Transfers.Include(t => t.Sender).Include(t => t.Receiver).FirstOrDefaultAsync(t => t.Id == entity.Id);
        }
    }
}
