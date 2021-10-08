using System;
using System.Collections.Generic;
using EndpointVersioning.Controllers.EndpointModels.Forecast.V1;
using EndpointVersioning.Controllers.EndpointModels.Forecast.V2;
using EndpointVersioning.Domain.Forecast;
using Microsoft.AspNetCore.Mvc;

namespace EndpointVersioning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly Forecaster _forecaster;

        public WeatherController(Forecaster forecaster)
        {
            _forecaster = forecaster;
        }

        [Obsolete("Please upgrade to v2, this version will be removed in December 2030.")]
        [HttpGet("forecast/")]
        [HttpGet("forecast/v1")]
        public IEnumerable<ForecastV1Response> GetForecastV1()
        {
            var from = DateTime.Today;
            var to = DateTime.Today.AddDays(5);
            var forecasts = _forecaster.Get(from, to);
            return ForecastV1Response.From(forecasts);
        }
        
        [HttpGet("forecast/v2")]
        public IEnumerable<ForecastV2Response> GetForecastV2(ForecastV2Request request)
        {
            var forecasts = _forecaster.Get(request.From, request.To);
            return ForecastV2Response.From(forecasts);
        }
    }
}