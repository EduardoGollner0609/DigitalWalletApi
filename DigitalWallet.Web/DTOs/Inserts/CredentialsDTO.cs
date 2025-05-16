using System.ComponentModel.DataAnnotations;

namespace DigitalWallet.Web.DTOs.Inserts
{
    public class CredentialsDTO
    {
        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; private set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        public string Password { get; private set; }

        public CredentialsDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
