using DigitalWalletApi.Domain.Entities;
using DigitalWalletApi.DTOs.Entities;
using DigitalWalletApi.Infra.Repositories.Abstractions;
using DigitalWalletApi.Services.Exceptions;

namespace DigitalWalletApi.Services
{
    public class WalletService
    {
        private readonly IUserRepository _userRepository;
        private readonly TransferService _transferService;

        public WalletService(IUserRepository userRepository, TransferService transferService)
        {
            _userRepository = userRepository;
            _transferService = transferService;
        }

        public async Task<UserMinDTO> Deposit(User? user, Guid id, decimal amount)
        {
            if (user == null)
            {
                user = await InstantiateById(id);
            }

            user.Deposit(amount);

            return await UpdateAndReturnUserMinDTO(user);
        }

        public async Task<UserMinDTO> Withdraw(User? user, Guid id, decimal amount)
        {
            if (user == null)
            {
                user = await InstantiateById(id);
            }

            user.Withdraw(amount);

            return await UpdateAndReturnUserMinDTO(user);
        }

        public async Task<TransferDTO> ExecuteTransfer(TransferMinDTO dto)
        {
            try
            {
                if (dto.Amount <= 0)
                {
                    throw new CreateEntityException("O valor da transferência deve ser maior que zero.");
                }

                User sender = await InstantiateById(dto.SenderId);
                User receiver = await InstantiateById(dto.ReceiverId);

                if (sender == null || receiver == null)
                {
                    throw new ResourceNotFoundException("Operação inválida: Uma das contas não existem!");
                }

                decimal amount = dto.Amount;

                UserMinDTO senderDTO = await Withdraw(sender, Guid.Empty, amount);
                UserMinDTO receiverDTO = await Deposit(receiver, Guid.Empty, amount);

                return await _transferService
                    .CreateAsync(new TransferDTO(senderDTO.Id, receiverDTO.Id, amount, DateTime.UtcNow));
            }
            catch (ResourceNotFoundException e)
            {
                throw new ResourceNotFoundException(e.Message);
            }
            catch(ArgumentException e)
            {
                throw new CreateEntityException(e.Message);
            }
        }

        private async Task<User> InstantiateById(Guid id)
        {
            User user = await _userRepository.FindByIdAsync(id);

            if (user == null)
            {
                throw new ResourceNotFoundException("Token inválido.");
            }

            return user;
        }

        private async Task<UserMinDTO> UpdateAndReturnUserMinDTO(User user)
        {
            user = await _userRepository.UpdateAsync(user);
            return new UserMinDTO(user);
        }
    }
}
