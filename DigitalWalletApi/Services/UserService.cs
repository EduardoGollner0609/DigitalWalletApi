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

        public async Task<User> CreateAsync(UserDTO dto)
        {
            User user = InstantiateUserByDTO(dto);
            await _repository.CreateAsync(user);
            return user;
        }

        public async Task<ICollection<User>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
        }

        public async Task<User> FindByIdAsync(Guid id)
        {
            User user = await _repository.FindByIdAsync(id);

            return user == null
                ? throw new ResourceNotFoundException($"Usuário do ID {id} não foi encontrado!")
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
