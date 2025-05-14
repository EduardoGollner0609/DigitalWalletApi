using DigitalWallet.Application.UseCases.DTOs.Abstractions;

namespace DigitalWallet.Application.UseCases.Transfer.Commands.CreateTransfer
{
    public class CreateTransferCommand : EntityResponseDTO
    {
        public Guid SenderId { get; private set; }
        public Guid ReceiverId { get; private set; }

        public decimal Amount { get; private set; }

        public DateTime Moment { get; private set; }

        public CreateTransferCommand(Guid senderId, Guid receiverId, decimal amount)
        {
            Id = Guid.NewGuid();
            SenderId = senderId;
            ReceiverId = receiverId;
            Amount = amount;
            Moment = DateTime.UtcNow;
        }

    }
}
