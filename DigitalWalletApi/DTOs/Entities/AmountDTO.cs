using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DigitalWalletApi.DTOs.Entities
{
    public class AmountDTO
    {
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor de depósito deve ser maior que zero.")]
        public decimal Amount { get; private set; }

        public AmountDTO() { }

        [JsonConstructor]
        public AmountDTO(decimal amount)
        {
            Amount = amount;
        }
    }
}
