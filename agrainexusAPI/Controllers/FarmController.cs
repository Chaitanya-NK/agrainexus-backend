using agrainexus.Business.IServices;
using agrainexus.Business.Services;
using agrainexus.Data.Models;
using agrainexus.Static;
using agrainexus.TokenGeneration.TokenInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace agrainexusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmController : ControllerBase
    {
        private readonly IFarmService _farmService;
        private readonly IToken _token;
        public FarmController(IFarmService iFarmService, IToken iToken)
        {
            _farmService = iFarmService;
            _token = iToken;
        }

        [HttpPost("AddFarm")]
        [ProducesResponseType(typeof(Farm), 201)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult AddFarm(Farm farm)
        {
            try
            {
                var getToken = Request.Headers["Authorization"];
                if(getToken.IsNullOrEmpty())
                {
                    return StatusCode(StatusCodes.Status401Unauthorized);
                }
                else
                {
                    string data = _farmService.AddFarmDetails(farm);
                    return Ok(data);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetFarmDetailsByUserId")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetFarmDetailsByUserId()
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
                    var tokenModel = _token.ReadToken(token);

                    if (tokenModel != null && !string.IsNullOrEmpty(tokenModel.Id))
                    {
                        int userId = Convert.ToInt32(tokenModel.Id);

                        List<Farm> data = _farmService.GetFarmDetailsByUserId(userId);

                        if (data != null && data.Count > 0)
                        {
                            return Ok(data);
                        }
                        else
                        {
                            return Ok("Data Not Found");
                        }
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status401Unauthorized);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred: " + ex.Message);
            }
        }




    }
}
