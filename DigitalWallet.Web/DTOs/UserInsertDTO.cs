using DigitalWallet.Domain.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace DigitalWallet.Web.DTOs
{
    public class UserInsertDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O nome deve ser informado.")]
        [StringLength(40, MinimumLength = 4, ErrorMessage = "O nome deve ter entre 4 a 40 caracteres.")]
        public string FirstName { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O sobrenome deve ser informado.")]
        [StringLength(40, MinimumLength = 6, ErrorMessage = "o sobrenome deve ter entre 6 a 40 caracteres.")]
        public string LastName { get; private set; }

        [Required(ErrorMessage = "Email deve ser informado.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; private set; }

        [Required(ErrorMessage = "Senha deve ser informada.")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 a 30 caracteres.")]
        public string Password { get; private set; }
        public Role Role { get; private set; }
        public decimal Balance { get; private set; }

        public UserInsertDTO() { }
        public UserInsertDTO(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
    }
}
