using System;
using System.Collections.Generic;
using ApiVersioning.Controllers.EndpointModels.Forecast.CurrentVersion;
using ApiVersioning.Controllers.EndpointModels.Forecast.Legacy;
using ApiVersioning.Domain.Forecast;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/weather")]
    [ApiExplorerSettings(GroupName = "weather")]
    [Route("api/weather")]  
    public class WeatherController : ControllerBase
    {
        private readonly Forecaster _forecaster;

        public WeatherController(Forecaster forecaster)
        {
            _forecaster = forecaster;
        }

        [ApiVersion("2")]
        [ApiVersion("1")]
        [Obsolete("Please upgrade to v3, this version will be removed in December 2030.")]
        [HttpGet("forecasts")]
        public IEnumerable<ForecastV1Response> GetV1Forecast()
        {
            var from = DateTime.Today;
            var to = DateTime.Today.AddDays(5);
            var forecasts = _forecaster.Get(from, to);
            return ForecastV1Response.From(forecasts);
        }
    
        [ApiExplorerSettings(GroupName = "Weather")]
        [ApiVersion("3")]
        [HttpGet("forecasts")]
        public IEnumerable<ForecastResponse> GetForecast(ForecastRange range)
        {
            var forecasts = _forecaster.Get(range.From, range.To);
            return ForecastResponse.From(forecasts);
        }
    }
}