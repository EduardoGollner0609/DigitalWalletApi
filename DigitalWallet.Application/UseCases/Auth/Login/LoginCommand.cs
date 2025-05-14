
namespace DigitalWallet.Application.UseCases.Auth.Login
{
    public class LoginCommand
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        public LoginCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
