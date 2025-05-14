using UserModel = DigitalWallet.Domain.Domain.Entities.User;
using DigitalWallet.Application.UseCases.Exceptions;
using DigitalWallet.Domain.Repositories.Abstractions;

namespace DigitalWallet.Application.UseCases.Wallet.Commands.Deposit
{
    public class DepositHandler
    {
        private readonly IUserRepository _userRepository;

        public DepositHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<DepositResponse> HandleAsync(DepositCommand command)
        {

            UserModel user = await _userRepository.FindByIdAsync(command.UserId);

            if (user == null)
                throw new ResourceNotFoundException("Erro ao depositar: Usuário não foi encontrado");

            user.Deposit(command.Amount);

            user = await _userRepository.UpdateAsync(user);

            return new DepositResponse(user);
        }
    }
}
