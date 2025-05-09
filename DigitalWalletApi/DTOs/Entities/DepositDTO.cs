using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DigitalWalletApi.DTOs.Entities
{
    public class DepositDTO
    {
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor de depósito deve ser maior que zero.")]
        public decimal Amount { get; private set; }

        public DepositDTO() { }

        [JsonConstructor]
        public DepositDTO(decimal amount)
        {
            Amount = amount;
        }
    }
}
