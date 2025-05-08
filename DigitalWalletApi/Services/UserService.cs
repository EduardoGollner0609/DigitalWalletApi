using DigitalWalletApi.Domain.Entities;
using DigitalWalletApi.DTOs.Entities;
using DigitalWalletApi.Infra.Repositories.Abstractions;
using DigitalWalletApi.Services.Exceptions;

namespace DigitalWalletApi.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserDTO> CreateAsync(UserDTO dto)
        {
            User user = InstantiateUserByDTO(dto);
            await _repository.CreateAsync(user);
            return new UserDTO(user);
        }

        public async Task<List<UserDTO>> FindAllAsync()
        {
            List<User> users = await _repository.FindAllAsync();
            return users.Select(u => new UserDTO(u)).ToList();
        }

        public async Task<UserDTO> FindByIdAsync(Guid id)
        {
            User user = await _repository.FindByIdAsync(id);

            return user == null
                ? throw new ResourceNotFoundException($"Usuário do ID {id} não foi encontrado!")
                : new UserDTO(user);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            User user = await _repository.FindByEmailAsync(email);

            return user == null
                ? throw new ResourceNotFoundException($"Usuário do email {email} não foi encontrado!")
                : user;
        }

        private User InstantiateUserByDTO(UserDTO dto)
        {
            return new User(dto.FirstName,
                dto.LastName,
                dto.Email,
                dto.Password,
                "user",
                0.00m);
        }
    }
}
