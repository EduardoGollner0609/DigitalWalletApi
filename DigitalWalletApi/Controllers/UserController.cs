using DigitalWalletApi.DTOs.Entities;
using DigitalWalletApi.Services;
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

    }
}
