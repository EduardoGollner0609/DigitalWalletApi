namespace DigitalWallet.Application.UseCases.Auth.Queries.Login
{
    public class LoginQuery
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        public LoginQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
