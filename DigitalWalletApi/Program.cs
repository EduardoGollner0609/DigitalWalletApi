using DigitalWalletApi.DTOs.Entities;
using DigitalWalletApi.Infra;
using DigitalWalletApi.Infra.Repositories.Abstractions;
using DigitalWalletApi.Infra.Repositories.Implementation;
using DigitalWalletApi.Services;
using Microsoft.AspNetCore.Identity;


namespace DigitalWalletApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.AddDatabaseConfiguration();
            builder.AddAuthConfigurarion();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITransferRepository, TransferRepository>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<AuthService>();
            builder.Services.AddScoped<TransferService>();
            builder.Services.AddScoped<PasswordHasher<UserDTO>>();
   
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
