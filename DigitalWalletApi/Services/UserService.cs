using DigitalWalletApi.Domain.Entities;
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
        private readonly PasswordHasher<UserDTO> _passwordHasher;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUserRepository repository, PasswordHasher<UserDTO> passwordHasher, IHttpContextAccessor httpContextAccessor)
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
                await _repository.CreateAsync(user);
                return new UserMinDTO(user);
            }
            catch(DbUpdateException e)
            {
                throw new CreateEntityException("Erro ao tentar criar usuário.");
            }
        }

        public async Task<UserDTO> FindByEmailAsync(string email)
        {
            User user = await _repository.FindByEmailAsync(email);

            return user == null
                ? throw new ResourceNotFoundException($"Usuário do email {email} não foi encontrado!")
                : new UserDTO(user);
        }

        public async Task<UserDTO> GetMe()
        {
            try
            {
                ClaimsIdentity identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;

                if (identity != null && identity.Claims != null)
                {
                    var email = identity.FindFirst(ClaimTypes.Name)?.Value;
                    var role = identity.FindFirst(ClaimTypes.Role)?.Value;

                    UserDTO user = await FindByEmailAsync(email);

                    return user == null ?
                       throw new ResourceNotFoundException()
                        : user;
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
            string newPassword = _passwordHasher.HashPassword(dto, dto.Password);
            string userRole = "user";
            return new User(dto.FirstName,
                dto.LastName,
                dto.Email,
                newPassword,
                userRole,
                0.00m);
        }
    }
}
