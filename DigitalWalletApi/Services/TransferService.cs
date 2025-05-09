using DigitalWalletApi.Domain.Entities;
using DigitalWalletApi.DTOs.Entities;
using DigitalWalletApi.Infra.Repositories.Abstractions;
using DigitalWalletApi.Services.Exceptions;
using System.Security.Cryptography.Xml;

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

        public async Task<List<TransferDTO>> FindAllAsync()
        {
            List<Transfer> transfers = await _repository.FindAllAsync();
            return transfers.Select(t => new TransferDTO(t)).ToList();
        }

        public async Task<TransferDTO> FindByIdAsync(Guid id)
        {
            Transfer transfer = await _repository.FindByIdAsync(id);

            return transfer == null
                ? throw new ResourceNotFoundException($"Transfêrenia do ID {id} não foi encontrada!")
                : new TransferDTO(transfer);
        }

        private Transfer InstantiateTransferByDTO(TransferDTO dto)
        {
            return new Transfer(
                dto.SenderId,
                dto.ReceiverId,
                dto.Amount
                );
        }
    }
}
