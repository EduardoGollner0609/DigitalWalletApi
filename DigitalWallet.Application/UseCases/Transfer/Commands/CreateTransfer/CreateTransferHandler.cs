using UserModel = DigitalWallet.Domain.Domain.Entities.User;
using TransferModel = DigitalWallet.Domain.Domain.Entities.Transfer;
using DigitalWallet.Application.UseCases.Exceptions;
using DigitalWallet.Domain.Repositories.Abstractions;

namespace DigitalWallet.Application.UseCases.Transfer.Commands.CreateTransfer
{
    public class CreateTransferHandler
    {
        private readonly ITransferRepository _trasnferRepository;
        private readonly IUserRepository _userRepository;

        public CreateTransferHandler(IUserRepository userRepository, ITransferRepository trasnferRepository)
        {
            _userRepository = userRepository;
            _trasnferRepository = trasnferRepository;
        }

        public async Task<CreateTransferResponse> HandleAsync(CreateTransferCommand command)
        {
            UserModel sender = await _userRepository.FindByIdAsync(command.SenderId);
            UserModel receiver = await _userRepository.FindByIdAsync(command.ReceiverId);

            if (sender == null || receiver == null)
                throw new ResourceNotFoundException("Erro ao transferir: Usuário não foi encontrado!");

            try
            {
                decimal amount = command.Amount;

                sender.Withdraw(amount);
                receiver.Deposit(amount);

                TransferModel transfer = new(
                    command.Id,
                    command.SenderId,
                    command.ReceiverId,
                    command.Amount,
                    command.Moment
                    );

                transfer = await _trasnferRepository.CreateAsync(transfer);

                return new CreateTransferResponse(transfer);
            }
            catch (ArgumentException e)
            {
                throw new CreateEntityException("Erro ao criar transferência: " + e.Message);
            }
        }
    }
}