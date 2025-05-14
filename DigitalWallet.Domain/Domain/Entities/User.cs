using DigitalWallet.Domain.Domain.Abstractions;
using DigitalWallet.Domain.Domain.Entities.Enums;

namespace DigitalWallet.Domain.Domain.Entities
{
    public class User : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public decimal Balance { get; private set; }
        public Role Role { get; private set; }
        public List<Transfer> TransfersSent { get; private set; } = new List<Transfer>();
        public List<Transfer> TransfersReceived { get; private set; } = new List<Transfer>();
        public User() { }

        public User(Guid id, string firstName, string lastName, string email, string password, Role role, decimal balance)
        {
            base.Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Role = role;
            Balance = balance;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                throw new ArgumentException("Saldo insuficiente!");
            }
            Balance -= amount;
        }

        public void AddTransferSent(Transfer transfer)
        {
            TransfersSent.Add(transfer);
        }

        public void RemoveTransferSent(Transfer transfer)
        {
            TransfersSent.Remove(transfer);
        }

        public void AddTransfersReceived(Transfer transfer)
        {
            TransfersReceived.Add(transfer);
        }

        public void RemoveTransfersReceived(Transfer transfer)
        {
            TransfersReceived.Remove(transfer);
        }

        public void SetPassword(string password)
        {
            Password = password;
        }
    }
}
