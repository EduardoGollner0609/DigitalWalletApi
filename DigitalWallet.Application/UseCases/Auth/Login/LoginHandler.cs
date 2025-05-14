using UserModel = DigitalWallet.Domain.Domain.Entities.User;
using DigitalWallet.Application.UseCases.Abstractions;
using DigitalWallet.Domain.Repositories.Abstractions;

namespace DigitalWallet.Application.UseCases.Auth.Login
{
    public class LoginHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;

        public LoginHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task<LoginResponse> HandleAsync(LoginCommand command)
        {
            UserModel user = await _userRepository.FindByEmailAsync(command.Email);

            if (user == null)
                throw new UnauthorizedAccessException("Credenciais inválidas!");

            if (_passwordHasher.Verify(command.Password, user.Password))
                throw new UnauthorizedAccessException("Credenciais inválidas!");

            string token = _tokenService.GetToken(user);

            return new LoginResponse(user, token);
        }
    }
}
