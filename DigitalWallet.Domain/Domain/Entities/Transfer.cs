using DigitalWallet.Domain.Domain.Abstractions;

namespace DigitalWallet.Domain.Domain.Entities
{
    public class Transfer : Entity
    {
        public Guid SenderId { get; private set; }
        public Guid ReceiverId { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Moment { get; private set; }
        public User Sender { get; private set; }
        public User Receiver { get; private set; }

        public Transfer() { }

        public Transfer(Guid id, Guid senderId, Guid receiverId, decimal amount, DateTime moment)
        {
            base.Id = id;
            SenderId = senderId;
            ReceiverId = receiverId;
            Amount = amount;
            Moment = moment;
        }

        public Transfer(Guid id, User sender, User receiver, decimal amount, DateTime moment)
        {
            base.Id = id;
            Sender = sender;
            Receiver = receiver;
            SenderId = sender.Id;
            ReceiverId = receiver.Id;
            Amount = amount;
            Moment = moment;
        }
    }
}
