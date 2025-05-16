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

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticatedDTO>> LoginAsync([FromBody] CredentialsDTO credentials)
        {
            try
            {
                var query = new LoginQuery(credentials.Email, credentials.Password);
                var response = await _loginHandler.HandleAsync(query);

                AuthenticatedDTO user = new AuthenticatedDTO(
                    new UserSimpleDTO(
                        response.User.Id,
                    response.User.Name, response.User.Email),
                    response.Role.ToString(),
                    response.Token);

                return Ok(user);
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(new ErrorResponseDTO(401, e.Message, DateTime.Now));
            }
        }
    }
}
