using System;
// ReSharper disable UnassignedGetOnlyAutoProperty

namespace ApiVersioning.Controllers.EndpointModels.Forecast.CurrentVersion
{
    public class ForecastUpdate
    {
        public DateTimeOffset Date { get; }
        public int TemperatureC { get; }
        public int TemperatureF { get; }
        public string Summary { get;  }
    }
}