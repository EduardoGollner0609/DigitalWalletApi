using DigitalWallet.Application.UseCases.Abstractions;
using DigitalWallet.Application.UseCases.Transfer.Commands.CreateTransfer;
using DigitalWallet.Application.UseCases.Transfer.Queries;
using DigitalWallet.Application.UseCases.User.Commands.CreateUser;
using DigitalWallet.Application.UseCases.Wallet.Commands.Deposit;
using DigitalWallet.Application.UseCases.Wallet.Queries.GetBalance;
using DigitalWallet.Domain.Repositories.Abstractions;
using DigitalWallet.Infrastructure.Auth.Implementation;
using DigitalWallet.Infrastructure.Repositories.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalWallet.Infrastructure.Configurations
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            {
                services.AddScoped<IUserRepository, UserRepository>();
                services.AddScoped<ITransferRepository, TransferRepository>();
                services.AddScoped<ITokenService, JwtTokenGenerator>();
                services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();

                services.AddScoped<CreateUserHandler>();
                services.AddScoped<CreateTransferHandler>();
                services.AddScoped<GetBalanceHandler>();
                services.AddScoped<DepositHandler>();
                services.AddScoped<GetSentTransfersHandler>();
            }
        }
    }
}
