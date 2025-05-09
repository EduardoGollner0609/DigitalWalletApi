using DigitalWalletApi.DTOs.Entities;
using DigitalWalletApi.DTOs.ExceptionsRepresentation;
using DigitalWalletApi.Services;
using DigitalWalletApi.Services.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<UserMinDTO>> CreateAsync(UserDTO dto)
        {
            try
            {
                UserMinDTO user = await _userService.CreateAsync(dto);
                string uri = $"/user/{user.Id}";
                return Created(uri, user);
            }
            catch (CreateEntityException e)
            {
                return BadRequest(new ErrorResponseDTO(400, e.Message));
            }
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<ActionResult<UserAuthenticatedDTO>> GetMe()
        {
            try
            {
                UserAuthenticatedDTO user = await _userService.GetMe();
                return Ok(user);
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(new ErrorResponseDTO(401, e.Message));
            }
        }


        [Authorize]
        [HttpGet("balance")]
        public async Task<ActionResult<double>> GetMyBalance()
        {
            UserMinDTO user = await _userService.GetMe();
            decimal balance = user.Balance;
            return Ok(balance);
        }
    }
}
