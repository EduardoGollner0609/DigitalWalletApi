using System.ComponentModel.DataAnnotations;
using DigitalWalletApi.Domain.Abstractions;

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

        public List<Transfer> Transfers { get; private set; } = new List<Transfer>();

        public User() { }

        public User(string firstName, string lastName, string email, string password, decimal amount, string role)
        {
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

        public void AddTransfer(Transfer transfer)
        {
            Transfers.Add(transfer);
        }

        public void RemoveTransfer(Transfer transfer)
        {
            Transfers.Remove(transfer);
        }
    }
}
