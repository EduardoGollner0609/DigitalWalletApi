using DigitalWallet.Application.UseCases.Abstractions;
using DigitalWallet.Application.UseCases.User.Commands.CreateUser;
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
            }
        }
    }
}
