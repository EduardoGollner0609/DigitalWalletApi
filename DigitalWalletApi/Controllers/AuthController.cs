using DigitalWalletApi.DTOs.Entities;
using DigitalWalletApi.Services;
using DigitalWalletApi.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
                return NotFound(new { message = e.Message });
            }
            catch (ResourceNotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }
    }
}
