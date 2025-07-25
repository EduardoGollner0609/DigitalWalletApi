﻿using UserModel = DigitalWallet.Domain.Domain.Entities.User;
using DigitalWallet.Application.UseCases.Exceptions;
using DigitalWallet.Domain.Repositories.Abstractions;
using DigitalWallet.Application.UseCases.Abstractions;

namespace DigitalWallet.Application.UseCases.User.Commands.CreateUser
{
    public class CreateUserHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public CreateUserHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<CreateUserResponse> HandleAsync(CreateUserCommand command)
        {
            if (await _userRepository.ExistsByEmail(command.Email))
                throw new CreateEntityException("Erro ao criar usuário: Email já existe!");

            string hashedPassword = _passwordHasher.Hash(command.Password);

            UserModel user = new(
                command.Id,
                command.FirstName,
                command.LastName,
                command.Email,
                hashedPassword,
                command.Role,
                command.Balance
                );

            user = await _userRepository.CreateAsync(user);

            return new CreateUserResponse(user);
        }
    }
}
