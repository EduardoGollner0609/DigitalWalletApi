using DigitalWallet.Application.UseCases.Auth.Queries.Login;
using DigitalWallet.Web.DTOs.Inserts;
using DigitalWallet.Web.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DigitalWallet.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly LoginHandler _loginHandler;

        public AuthController(LoginHandler loginHandler)
        {
            _loginHandler = loginHandler;
        }

        [HttpPost]
        public async Task<ActionResult<AuthenticatedDTO>> LoginAsync([FromBody] CredentialsDTO credentials)
        {
            var command = new LoginQuery(credentials.Email, credentials.Password);
            var response = await _loginHandler.HandleAsync(command);

            AuthenticatedDTO user = new AuthenticatedDTO(
                new UserSimpleDTO(
                    response.User.Id,
                response.User.Name, response.User.Email),
                response.Role,
                response.Token);

            return Ok(user);
        }
    }
}
