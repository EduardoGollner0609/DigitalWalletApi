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
        private readonly WalletService _walletService;

        public UserController(UserService userService, WalletService walletService)
        {
            _userService = userService;
            _walletService = walletService;
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
            try
            {
                UserMinDTO user = await _userService.GetMe();
                decimal balance = user.Balance;
                return Ok(balance);
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(new ErrorResponseDTO(401, e.Message));
            }
        }

        [Authorize]
        [HttpPut("deposit")]
        public async Task<ActionResult<UserMinDTO>> Deposit([FromBody] DepositDTO deposit)
        {
            try
            {
                UserMinDTO user = await _userService.GetMe();
                user = await _walletService.Deposit(user, deposit);
                return Ok(user);
            }
            catch (Exception e) when (e is UnauthorizedAccessException || e is ResourceNotFoundException)
            {
                return Unauthorized(new ErrorResponseDTO(401, e.Message));
            }
        }
    }
}
