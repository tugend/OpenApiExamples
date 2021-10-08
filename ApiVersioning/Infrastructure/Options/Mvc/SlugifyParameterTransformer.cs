using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Routing;

namespace ApiVersioning.Infrastructure.Options.Mvc
{
    /// <summary>
    /// Transform all controller routes to slug-case
    /// Example: Weather/V1/ForecastReport => weather/v1/forecast-report
    /// </summary>
    public class SlugifyParameterTransformer : IOutboundParameterTransformer
    {
        public string TransformOutbound(object value)
        {
            // Slugify value
            return value == null 
                ? null 
                : Regex
                    .Replace(value.ToString()!, "([a-z])([A-Z])", "$1-$2")
                    .ToLower();
        }
    }
}