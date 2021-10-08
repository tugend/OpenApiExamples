using System;

namespace ApiVersioning.Domain.Forecast.ForecasterModels
{
    public class WeatherForecast
    {
        public DateTimeOffset Date { get; }
        public int TemperatureC { get; }

        public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);

        public string Summary { get;  }

        public WeatherForecast(DateTimeOffset date, int temperatureC, string summary)
        {
            Date = date;
            TemperatureC = temperatureC;
            Summary = summary;
        }
    }
}