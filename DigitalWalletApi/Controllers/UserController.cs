using DigitalWalletApi.DTOs.Entities;
using DigitalWalletApi.Services;
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
        public async Task<ActionResult<UserDTO>> CreateAsync(UserDTO dto)
        {
            UserDTO userDTO = await _userService.CreateAsync(dto);
            string uri = $"/user/{userDTO.Id}";
            return Created(uri, userDTO);
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<ActionResult<UserDTO>> GetMe()
        {
            try
            {
                UserDTO user = await _userService.GetMe();
                return Ok(user);
            }
            catch (UnauthorizedAccessException e)
            {
                return NotFound(new { message = e.Message });
            }
        }


        [Authorize]
        [HttpGet("balance")]
        public async Task<ActionResult<double>> GetMyBalance()
        {
            UserDTO userDTO = await _userService.GetMe();
            decimal balance = userDTO.Balance;
            return Ok(balance);
        }
    }
}
