using DigitalWalletApi.DTOs.Entities;
using DigitalWalletApi.Services.Exceptions;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DigitalWalletApi.Services
{
    public class AuthService
    {
        private readonly UserService _userService;
        private readonly PasswordHasher<UserDTO> _passwordHasher;

        public AuthService(UserService userService, PasswordHasher<UserDTO> passwordHasher)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
        }

        public async Task<Object> Login(CredentialsDTO dto)
        {
            try
            {
                UserDTO user = await _userService.FindByEmailAsync(dto.Email);

                var verifiyPassword = _passwordHasher.VerifyHashedPassword(user, user.Password, dto.Password);

                if (verifiyPassword == PasswordVerificationResult.Failed)
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
            catch (ResourceNotFoundException)
            {
                throw new UnauthorizedAccessException("Credenciais inválidas.");
            }
        }
    }
}
