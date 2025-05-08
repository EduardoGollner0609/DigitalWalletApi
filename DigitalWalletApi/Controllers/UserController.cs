using DigitalWalletApi.Domain.Entities;
using DigitalWalletApi.DTOs.Entities;
using DigitalWalletApi.Services;
using DigitalWalletApi.Services.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace DigitalWalletApi.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateAsync(UserDTO dto)
        {
            UserDTO userDTO = await _userService.CreateAsync(dto);
            string uri = $"/users/{userDTO.Id}";
            return Created(uri, userDTO);
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<ActionResult<UserDTO>> GetUserClaims()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;

                if (identity != null && identity.Claims != null)
                {
                    var email = identity.FindFirst(ClaimTypes.Name)?.Value;
                    var role = identity.FindFirst(ClaimTypes.Role)?.Value;

                    UserDTO user = await _userService.FindByEmailAsync(email);

                    return user == null ?
                        NotFound()
                        : Ok(new
                        {
                            user,
                            role
                        });
                }
                return Unauthorized("Token inválido ou ausente.");
            }
            catch (ResourceNotFoundException)
            {
                return Unauthorized("Token inválido ou ausente.");
            }
        }
    }
}
