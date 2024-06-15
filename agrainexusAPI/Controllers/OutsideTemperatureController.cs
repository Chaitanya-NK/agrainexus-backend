using agrainexus.Business.IServices;
using agrainexus.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace agrainexusAPI.Controllers
{
    [Route("api/temperature")]
    [ApiController]
    public class OutsideTemperatureController : ControllerBase
    {
        private readonly IOutsideTemperatureService _outsideTemperatureService;

        public OutsideTemperatureController(IOutsideTemperatureService outsideTemperatureService)
        {
            _outsideTemperatureService = outsideTemperatureService;
        }

        [HttpGet]
        public async Task<ActionResult<OutsideTemperature>> GetOutsideTemperature()
        {
            double temperature = await _outsideTemperatureService.GetOutsideTemperature();

            OutsideTemperature outsideTemperature = new OutsideTemperature
            {
                Temperature = temperature
            };

            return outsideTemperature;
        }
    }
}
