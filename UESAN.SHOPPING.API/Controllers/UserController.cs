using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.SHOPPING.CORE.Core.DTOs;
using UESAN.SHOPPING.CORE.Core.Interfaces;
using UESAN.SHOPPING.CORE.Core.Services;

namespace UESAN.SHOPPING.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> SignIn([FromQuery] string email, [FromQuery] string password)
        {
            var user = await _userService.SignIn(email, password);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] UserCreateDTO userCreateDTO)
        {
            if (userCreateDTO == null)
            {
                return BadRequest();
            }
            var userId = await _userService.SignUp(userCreateDTO);
            return Ok(userId);
        }
    }
}
