using System;
using System.Collections.Generic;
using System.Linq;
using EndpointVersioning.Domain.Forecast.ForecasterModels;

namespace EndpointVersioning.Controllers.EndpointModels.Forecast.V2
{
    public class ForecastV2Response
    {
        public DateTimeOffset Date { get; }
        public int TemperatureC { get; }
        public int TemperatureF { get; }
        public string Summary { get;  }

        public ForecastV2Response(DateTimeOffset date, int temperatureC, int temperatureF, string summary)
        {
            Date = date;
            TemperatureC = temperatureC;
            TemperatureF = temperatureF;
            Summary = summary;
        }
        
        public static IEnumerable<ForecastV2Response> From(IEnumerable<WeatherForecast> forecasts) =>
            forecasts.Select(x => new ForecastV2Response(x.Date, x.TemperatureC, x.TemperatureF, x.Summary));
    }
}