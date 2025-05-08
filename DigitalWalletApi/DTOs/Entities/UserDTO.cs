using DigitalWalletApi.Domain.Entities;
using DigitalWalletApi.DTOs.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace DigitalWalletApi.DTOs.Entities
{
    public class UserDTO : EntityDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O Nome deve ser informado.")]
        public string FirstName { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Sobrenome deve ser informado.")]
        public string LastName { get; private set; }

        [Required(ErrorMessage = "Email deve ser informado.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; private set; }

        [Required(ErrorMessage = "Senha deve ser informada.")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 a 30 caracteres.")]
        public string Password { get; private set; }
        public decimal Balance { get; private set; }

        public List<Transfer> Transfers { get; private set; } = new List<Transfer>();

        public UserDTO(string firstName, string lastName, string email, string password, decimal balance)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Balance = balance;
        }
    }
}
