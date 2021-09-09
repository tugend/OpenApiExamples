using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SimpleVersioning.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]  
    public class WeatherForecastController : ControllerBase
    {
        private readonly Forecaster _forecaster;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(Forecaster forecaster, ILogger<WeatherForecastController> logger)
        {
            _forecaster = forecaster;
            _logger = logger;
        }

        
        [ApiVersion("1.0")]
        [HttpGet]
        public IEnumerable<WeatherForecast> GetV1()
        {
            return _forecaster.Get();
        }
        
        [ApiVersion("2.0", Deprecated = true)]
        [HttpGet]
        public IEnumerable<WeatherForecast> GetV2(DateTimeOffset from, DateTimeOffset to)
        {
            return _forecaster.Get();
        }
        
        [ApiVersion("3.0")]
        [ApiVersion("2.0")]
        [HttpDelete]
        public IEnumerable<WeatherForecast> DoV2()
        {
            return _forecaster.Get();
        }
    }
}