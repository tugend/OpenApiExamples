using System;
using System.Collections.Generic;
using System.Linq;
using EndpointVersioning.Domain.Forecast.ForecasterModels;

namespace EndpointVersioning.Controllers.EndpointModels.Forecast.V1
{
    [Obsolete]
    public class ForecastV1Response
    {
        public DateTimeOffset Date { get; }
        public int TemperatureC { get; }
        public int TemperatureF { get; }
        public string Summary { get;  }

        public ForecastV1Response(DateTimeOffset date, int temperatureC, int temperatureF, string summary)
        {
            Date = date;
            TemperatureC = temperatureC;
            TemperatureF = temperatureF;
            Summary = summary;
        }
        
        public static IEnumerable<ForecastV1Response> From(IEnumerable<WeatherForecast> weatherForecasts) =>
            weatherForecasts.Select(x =>
                new ForecastV1Response(x.Date, x.TemperatureC, x.TemperatureF, x.Summary));
    }
}