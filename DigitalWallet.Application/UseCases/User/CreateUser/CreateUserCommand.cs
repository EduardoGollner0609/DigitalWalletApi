using DigitalWallet.Application.UseCases.DTOs.Abstractions;
using DigitalWallet.Domain.Domain.Entities.Enums;

namespace DigitalWallet.Application.UseCases.User.CreateUser
{
    public class CreateUserCommand : EntityDTO
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Role Role { get; private set; }
        public decimal Balance { get; private set; }

        public CreateUserCommand(string firstName, string lastName, string email, string password)
        {
            base.Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Role = Role.User;
            Balance = 0;
        }
    }
}
