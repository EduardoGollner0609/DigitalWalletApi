using DigitalWalletApi.Domain.Entities;
using DigitalWalletApi.DTOs.Entities;
using DigitalWalletApi.Services.Exceptions;

namespace DigitalWalletApi.Services
{
    public class AuthService
    {
        private readonly UserService _userService;

        public AuthService(UserService userService)
        {
            _userService = userService;
        }

        public async Task<Object> Login(CredentialsDTO dto)
        {
            try
            {
                User user = await _userService.FindByEmailAsync(dto.Email);

                if (!string.Equals(user.Password, dto.Password, StringComparison.CurrentCultureIgnoreCase))
                {
                    throw new UnauthorizedAccessException("Credenciais inválidas.");
                }

                var token = TokenService.GeneratedToken(user);

                dto.Password = "";

                return new
                {
                    user,
                    token
                };
            }
            catch (ResourceNotFoundException e)
            {
                throw new ResourceNotFoundException(e.Message);
            }
        }
    }
}
