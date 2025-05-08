using DigitalWalletApi.DTOs.Entities;
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
        public async Task<ActionResult<Object>> Login(CredentialsDTO dto)
        {
            try
            {
                var token = await _authService.Login(dto);
                return Ok(token);
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(new { message = e.Message });
            }
        }
    }
}
