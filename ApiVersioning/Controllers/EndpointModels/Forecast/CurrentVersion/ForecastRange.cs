using System;
using System.ComponentModel.DataAnnotations;

namespace ApiVersioning.Controllers.EndpointModels.Forecast.CurrentVersion
{
    public class ForecastRange
    {
        [Required]
        public DateTime From { get; init; }
        
        [Required]
        public DateTime To { get; init; }
    }
}