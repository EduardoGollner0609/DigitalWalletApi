using DigitalWalletApi.Domain.Entities;
using DigitalWalletApi.DTOs.Entities;
using DigitalWalletApi.Infra.Repositories.Abstractions;
using DigitalWalletApi.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DigitalWalletApi.Services
{
    public class TransferService
    {
        private readonly ITransferRepository _repository;

        public TransferService(ITransferRepository repository)
        {
            _repository = repository;
        }

        public async Task<TransferDTO> CreateAsync(TransferDTO dto)
        {
            try
            {
                Transfer transfer = InstantiateTransferByDTO(dto);
                transfer = await _repository.CreateAsync(transfer);
                return new TransferDTO(transfer);
            }
            catch (DbUpdateException e)
            {
                throw new CreateEntityException("Erro ao criar transferência.");
            }
        }

        private Transfer InstantiateTransferByDTO(TransferDTO dto)
        {
            return new Transfer(
                dto.SenderId,
                dto.ReceiverId,
                dto.Amount,
                dto.Moment
                );
        }
    }
}
