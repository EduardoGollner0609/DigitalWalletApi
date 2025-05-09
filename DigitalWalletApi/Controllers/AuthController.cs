using DigitalWalletApi.DTOs.Entities;
using DigitalWalletApi.DTOs.ExceptionsRepresentation;
using DigitalWalletApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DigitalWalletApi.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserAuthenticatedDTO>> Login(CredentialsDTO dto)
        {
            try
            {
                UserAuthenticatedDTO userAuthenticated = await _authService.Login(dto);
                return Ok(userAuthenticated);
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(new ErrorResponseDTO(401, e.Message));
            }
        }
    }
}
