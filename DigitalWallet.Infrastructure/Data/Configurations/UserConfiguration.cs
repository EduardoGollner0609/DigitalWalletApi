using DigitalWallet.Domain.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalWallet.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName)
                   .HasColumnType("varchar(40)")
                   .IsRequired();

            builder.Property(u => u.LastName)
                   .HasColumnType("varchar(40)")
                   .IsRequired();

            builder.Property(u => u.Email)
                   .IsRequired();

            builder.Property(u => u.Password)
                   .IsRequired();

            builder.Property(u => u.Balance)
                   .HasColumnType("decimal(18,2)");

            builder.Property(u => u.Role)
                   .HasConversion<string>();

            builder.HasMany(u => u.TransfersSent)
                   .WithOne(t => t.Sender)
                   .HasForeignKey(t => t.SenderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.TransfersReceived)
                   .WithOne(t => t.Receiver)
                   .HasForeignKey(t => t.ReceiverId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
