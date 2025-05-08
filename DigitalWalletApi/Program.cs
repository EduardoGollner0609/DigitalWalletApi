using DigitalWalletApi.Infra;
using DigitalWalletApi.Infra.Repositories.Abstractions;
using DigitalWalletApi.Infra.Repositories.Implementation;
using DigitalWalletApi.Services;

namespace DigitalWalletApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.AddDatabaseConfiguration();

            builder.AddAuthConfigurarion();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITransferRepository, TransferRepository>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<AuthService>();

            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
