using DigitalWallet.Application.UseCases.Exceptions;
using DigitalWallet.Application.UseCases.User.Commands.CreateUser;
using DigitalWallet.Web.DTOs.Inserts;
using DigitalWallet.Web.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DigitalWallet.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CreateUserHandler _createUserHandler;

        public UserController(CreateUserHandler createUserHandler)
        {
            _createUserHandler = createUserHandler;
        }

        [HttpPost]
        public async Task<ActionResult<UserSimpleDTO>> CreateUserAsync([FromBody] UserInsertDTO dto)
        {
            try
            {
                var command = new CreateUserCommand(dto.FirstName, dto.LastName, dto.Email, dto.Password)
                var response = await _createUserHandler.HandleAsync(command);

                UserSimpleDTO user = new(response.Id, response.Name, response.Email);
                return Created(string.Empty, user);
            }
            catch (CreateEntityException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
