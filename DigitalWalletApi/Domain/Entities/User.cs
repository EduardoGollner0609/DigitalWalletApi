using DigitalWalletApi.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalWalletApi.Domain.Entities
{
    public class User : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public decimal Balance { get; private set; }
        public string Role { get; private set; }

        [InverseProperty("Sender")]
        public List<Transfer> TransfersSent { get; private set; } = new List<Transfer>();

        [InverseProperty("Receiver")]
        public List<Transfer> TransfersReceived { get; private set; } = new List<Transfer>();

        public User() { }

        public User(string firstName, string lastName, string email, string password, string role, decimal amount)
        {
            base.Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Role = role;
            Deposit(amount);
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                Balance = amount;
            }
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
    }
}
