using System;
using System.Collections.Generic;
using System.Linq;
using ApiVersioning.Domain.Forecast.ForecasterModels;

namespace ApiVersioning.Controllers.EndpointModels.Forecast.CurrentVersion
{
    public class ForecastResponse
    {
        public DateTimeOffset Date { get; }
        public int TemperatureC { get; }
        public int TemperatureF { get; }
        public string Summary { get;  }

        public ForecastResponse(DateTimeOffset date, int temperatureC, int temperatureF, string summary)
        {
            Date = date;
            TemperatureC = temperatureC;
            TemperatureF = temperatureF;
            Summary = summary;
        }
        
        public static IEnumerable<ForecastResponse> From(IEnumerable<WeatherForecast> weatherForecasts) =>
            weatherForecasts.Select(x =>
                new ForecastResponse(x.Date, x.TemperatureC, x.TemperatureF, x.Summary));
    }
}