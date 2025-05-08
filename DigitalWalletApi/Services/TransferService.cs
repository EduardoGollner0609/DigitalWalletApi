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

        public async Task<Transfer> CreateAsync(TransferDTO dto)
        {
            Transfer transfer = InstantiateTransferByDTO(dto);
            await _repository.CreateAsync(transfer);
            return transfer;
        }

        public async Task<List<Transfer>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
        }

        public async Task<Transfer> FindByIdAsync(Guid id)
        {
            Transfer transfer = await _repository.FindByIdAsync(id);

            return transfer == null
                ? throw new ResourceNotFoundException($"Transfêrenia do ID {id} não foi encontrada!")
                : transfer;
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
