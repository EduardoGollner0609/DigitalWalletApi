using System.ComponentModel.DataAnnotations;
using DigitalWalletApi.Domain.Abstractions;

namespace DigitalWalletApi.Domain.Entities
{
    public class User : Entity
    {
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; private set; }

        [Required(AllowEmptyStrings = false)]
        public string LastName { get; private set; }

        [EmailAddress]
        public string Email { get; private set; }

        [MinLength(6)]
        public string Password { get; private set; }

        [Required]
        public decimal Balance { get; private set; }

        [Required]
        public string Role { get; private set; }

        public List<Transfer> Transfers { get; private set; } = new List<Transfer>();

        public User() { }

        public User(Guid id, string firstName, string lastName, string email, string password, decimal amount, string role) : base()
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
