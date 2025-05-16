using DigitalWallet.Web.DTOs.Abstractions;

namespace DigitalWallet.Web.DTOs.Responses
{
    public class TransferSimpleDTO : EntityResponseDTO
    {
        public UserSimpleDTO Sender { get; private set; }
        public UserSimpleDTO Receiver { get; private set; }
        public decimal Amount { get; private set; }

        public DateTime Moment { get; private set; }

        public TransferSimpleDTO(Guid id, UserSimpleDTO sender, UserSimpleDTO receiver, decimal amount, DateTime moment)
        {
            Id = id;
            Sender = sender;
            Receiver = receiver;
            Amount = amount;
            Sender = sender;
            Receiver = receiver;
            Moment = moment;
        }
    }
}
