using DigitalWalletApi.Domain.Entities;
using DigitalWalletApi.Domain.Entities.Enums;
using DigitalWalletApi.DTOs.Entities;
using DigitalWalletApi.Infra.Repositories.Abstractions;
using DigitalWalletApi.Services.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DigitalWalletApi.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUserRepository repository, PasswordHasher<User> passwordHasher, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserMinDTO> CreateAsync(UserDTO dto)
        {
            try
            {
                if (await _repository.ExistsByEmailAsync(dto.Email))
                {
                    throw new CreateEntityException("Erro ao tentar criar usuário, email já cadastrado.");
                }

                User user = InstantiateUserByDTO(dto);
                user.SetPassword(_passwordHasher.HashPassword(user, user.Password));
                await _repository.CreateAsync(user);
                return new UserMinDTO(user);
            }
            catch (DbUpdateException e)
            {
                throw new CreateEntityException("Erro ao tentar criar usuário.");
            }
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            User user = await _repository.FindByEmailAsync(email);

            return user == null
                ? throw new ResourceNotFoundException($"Usuário do email {email} não foi encontrado!")
                : user;
        }

        public async Task<UserAuthenticatedDTO> GetMe()
        {
            try
            {
                ClaimsIdentity identity = _httpContextAccessor
                    .HttpContext.User.Identity as ClaimsIdentity;

                if (identity != null && identity.Claims != null)
                {
                    var email = identity.FindFirst(ClaimTypes.Name)?.Value ?? string.Empty;
                    var role = identity.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty;

                    User user = await FindByEmailAsync(email);

                    return user == null
                        ? throw new UnauthorizedAccessException("Credenciais inválidas.")
                        : new UserAuthenticatedDTO(user, Enum.Parse<Role>(role));
                }
                throw new UnauthorizedAccessException("Token inválido ou ausente.");
            }
            catch (ResourceNotFoundException)
            {
                throw new UnauthorizedAccessException("Token inválido ou ausente.");
            }
        }

        private User InstantiateUserByDTO(UserDTO dto)
        {
            return new User(dto.FirstName,
                dto.LastName,
                dto.Email,
                dto.Password,
                Role.User,
                0.00m);
        }
    }
}
