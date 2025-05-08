namespace DigitalWalletApi.DTOs.Entities
{
    public class CredentialsDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public CredentialsDTO() { }

        public CredentialsDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
