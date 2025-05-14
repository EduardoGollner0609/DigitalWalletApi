using TransferModel = DigitalWallet.Domain.Domain.Entities.Transfer;
using DigitalWallet.Application.UseCases.Exceptions;
using DigitalWallet.Domain.Repositories.Abstractions;

namespace DigitalWallet.Application.UseCases.Transfer.CreateTransfer
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
            if (!(await VerifyExistsUsers(command.SenderId, command.ReceiverId)))
                throw new ResourceNotFoundException("Erro ao transferir: Usuário não foi encontrado!");

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

        private async Task<bool> VerifyExistsUsers(Guid senderId, Guid receiverId)
        {
            if (await _userRepository.ExistsByIdAsync(senderId))
                return false;

            if (await _userRepository.ExistsByIdAsync(receiverId))
                return false;

            return true;
        }
    }
}
