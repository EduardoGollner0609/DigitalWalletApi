﻿
namespace DigitalWallet.Application.UseCases.Abstractions
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string password, string hash);
    }
}
