using DigitalWallet.Web.DTOs.Abstractions;
using DigitalWallet.Domain.Domain.Entities;

namespace DigitalWallet.Web.DTOs
{
    public class UserSimpleDTO : EntityResponseDTO
    {
        public string Name { get; private set; }
        public string Email { get; private set; }

        public UserSimpleDTO(Guid id, string name, string email)
        {
            base.Id = id;
            Name = name;
            Email = email;
        }
    }
}
