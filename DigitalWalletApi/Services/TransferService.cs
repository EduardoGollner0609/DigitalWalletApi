using DigitalWalletApi.Domain.Entities;
using DigitalWalletApi.DTOs.Entities;
using DigitalWalletApi.Infra.Repositories.Abstractions;

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
            Transfer transfer = InstantiateTransferByDTO(dto);
            await _repository.CreateAsync(transfer);
            return new TransferDTO(transfer);
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
