using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherApi _api;

        public WeatherForecastController(AppSettings settings)
        {
            _api = new WeatherApi(settings.ApiSettings.WeatherApiKey);
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return _api.Get();
        }
    }
}
