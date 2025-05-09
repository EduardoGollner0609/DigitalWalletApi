using DigitalWalletApi.Domain.Entities;
using DigitalWalletApi.DTOs.Entities;
using DigitalWalletApi.Services.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace DigitalWalletApi.Services
{
    public class AuthService
    {
        private readonly UserService _userService;
        private readonly PasswordHasher<User> _passwordHasher;

        public AuthService(UserService userService, PasswordHasher<User> passwordHasher)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserAuthenticatedLoginDTO> Login(CredentialsDTO dto)
        {
            try
            {
                User user = await _userService.FindByEmailAsync(dto.Email);

                var verifyHashedPasswordResult = _passwordHasher.VerifyHashedPassword(user, user.Password, dto.Password);

                if (verifyHashedPasswordResult == PasswordVerificationResult.Failed)
                {
                    throw new UnauthorizedAccessException("Credenciais inválidas.");
                }

                var token = TokenService.GeneratedToken(user);

                return new UserAuthenticatedLoginDTO(user, user.Role, token);
            }
            catch (ResourceNotFoundException)
            {
                throw new UnauthorizedAccessException("Credenciais inválidas.");
            }
        }
    }
}
