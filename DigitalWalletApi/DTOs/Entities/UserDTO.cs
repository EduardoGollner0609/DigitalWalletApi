using DigitalWalletApi.Domain.Entities;
using DigitalWalletApi.DTOs.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DigitalWalletApi.DTOs.Entities
{
    public class UserDTO : EntityDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O Nome deve ser informado.")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Sobrenome deve ser informado.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email deve ser informado.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha deve ser informada.")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 a 30 caracteres.")]
        public string Password { get; private set; }
        public decimal Balance { get; private set; }

        public UserDTO() { }

        [JsonConstructor]
        public UserDTO(string firstName, string lastName, string email, string password, decimal balance)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Balance = balance;
        }

        public UserDTO(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Password = user.Password;
            Balance = user.Balance;
        }
    }
}
