using System;
using System.ComponentModel.DataAnnotations;

namespace EndpointVersioning.Controllers.EndpointModels.Forecast.V2
{
    public class ForecastV2Request
    {
        [Required]
        public DateTime From { get; init; }
        
        [Required]
        public DateTime To { get; init; }
    }
}