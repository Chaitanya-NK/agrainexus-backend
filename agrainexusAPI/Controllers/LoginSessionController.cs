using agrainexus.Business.IServices;
using agrainexus.Data.Models;
using agrainexus.TokenGeneration.TokenInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace agrainexusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginSessionController : ControllerBase
    {
        private readonly ILoginSessionService _loginSessionService;
        private readonly IToken _iToken;
        public LoginSessionController(ILoginSessionService loginSessionService, IToken iToken)
        {
            _loginSessionService = loginSessionService;
            _iToken = iToken;
        }

        [HttpPost("login")]
        public IActionResult CreateLoginSession([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var getToken = Request.Headers["Authorization"];
                var token = _iToken.ReadToken(getToken);
                if (getToken.IsNullOrEmpty())
                {
                    return StatusCode(StatusCodes.Status401Unauthorized);
                }
                else
                {
                    _loginSessionService.Create(loginRequest.UserName, DateTime.Now);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An unknown error has occurred while creating the login session {ex.Message}");
            }
        }

        [HttpPost("logout")]
        public IActionResult LogoutSession([FromBody] LogoutRequest logoutRequest)
        {
            try
            {
                _loginSessionService.LogoutSession(logoutRequest.SessionId, DateTime.Now);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while logging out the session: {ex.Message}");
            }
        }

        [HttpGet("active-count")]
        public IActionResult GetActiveLoginCount()
        {
            try
            {
                int activeLoginCount = _loginSessionService.GetActiveLoginCount();
                return Ok(new { ActiveLoginCount = activeLoginCount });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving the active login count: {ex.Message}");
            }
        }

        [HttpGet("session-id")]
        public IActionResult GetSessionIdByUserName()
        {
            try
            {
                var getToken = Request.Headers["Authorization"];
                if (getToken.IsNullOrEmpty())
                {
                    return StatusCode(StatusCodes.Status401Unauthorized);
                }
                else
                {
                    var token = Request.Headers["Authorization"].ToString();
                    var tokenModel = _iToken.ReadToken(token);

                    if (tokenModel != null && !string.IsNullOrEmpty(tokenModel.UserName))
                    {
                        string userName = tokenModel.UserName;
                        string sessionId = _loginSessionService.GetSessionIdByUserName(userName);
                        return Ok(sessionId);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status401Unauthorized);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving the session id: {ex.Message}");
            }
        }
    }

    public class LoginRequest
    {
        public string UserName { get; set; }
    }

    public class LogoutRequest
    {
        public string SessionId { get; set; }
    }
}
