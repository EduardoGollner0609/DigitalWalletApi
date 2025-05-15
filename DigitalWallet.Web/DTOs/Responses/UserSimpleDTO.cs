using DigitalWallet.Web.DTOs.Abstractions;


namespace DigitalWallet.Web.DTOs.Responses
{
    public class UserSimpleDTO : EntityResponseDTO
    {
        public string Name { get; private set; }
        public string Email { get; private set; }

        public UserSimpleDTO(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}
