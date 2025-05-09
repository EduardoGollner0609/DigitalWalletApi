using DigitalWalletApi.Domain.Entities;
using DigitalWalletApi.DTOs.Entities;
using DigitalWalletApi.Infra.Repositories.Abstractions;
using DigitalWalletApi.Services.Exceptions;

namespace DigitalWalletApi.Services
{
    public class WalletService
    {
        private readonly IUserRepository _userRepository;

        public WalletService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserMinDTO> Deposit(UserMinDTO dto, DepositDTO deposit)
        {
            if(deposit.Amount <= 0)
            {
                throw new ArgumentException("A quantia é obrigatória e deve ser maior que zero.");
            }
            User user = await _userRepository.FindByEmailAsync(dto.Email);

            if (user == null)
            {
                throw new ResourceNotFoundException("Token inválido.");
            }

            user.Deposit(deposit.Amount);
            user = await _userRepository.UpdateAsync(user);
            return new UserMinDTO(user);
        }
    }
}
