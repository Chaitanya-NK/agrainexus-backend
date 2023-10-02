using agrainexus.Business.IServices;
using agrainexus.Data.Models;
using agrainexus.Static;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace agrainexusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService iUserService)
        {
            _userService = iUserService;
        }

        [HttpPost("Register")]
        [ProducesResponseType(typeof(User), 201)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Register(User user)
        {
            try
            {
                string data = _userService.Register(user);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("Login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public IActionResult Login(UserDto userDto)
        {
            try
            {
                string data = _userService.UserLogin(userDto);
                if(data == StaticLogin.InvalidUser)
                {
                    return Unauthorized(new { isLoggedIn = false });
                }
                else
                {
                    return Ok(new { isLoggedIn = true, Token = data });
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
