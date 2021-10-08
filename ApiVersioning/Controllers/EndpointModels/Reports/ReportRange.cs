using System;
using System.ComponentModel.DataAnnotations;

namespace ApiVersioning.Controllers.EndpointModels.Reports
{
    public class ReportRange
    {
        [Required]
        public DateTime From { get; init; }
        
        [Required]
        public DateTime To { get; init; }
    }
}