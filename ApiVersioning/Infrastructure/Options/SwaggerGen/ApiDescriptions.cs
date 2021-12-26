using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

namespace ApiVersioning.Infrastructure.Options.SwaggerGen
{
    /// <summary>
    /// The place to update the textual API documentation.
    /// TODO: Can easily be nicely separated out into APIs ect. depending on the complexity required.
    /// </summary>
    public static class ApiDescriptions
    {
        private const string WeatherV1 = 
@"
## Initial API
* Add: Initial version of `GET /forecast`, will be removed after 2021 December.
";
        private const string WeatherV2 = 
@"
## Changes
* Breaking: `GET /forecast` now requires date range to be specified.
";
        private const string WeatherV3 = 
@"
## Changes
* Breaking: Major format changes for forecast data.
* Add: Endpoint for fetching detailed forecast reports `GET /reports`
";
        
        private const string ReportsV1 = 
            @"
## Initial API: TODO
";
        private const string ReportsV2 = 
            @"
* Breaking: TODO
";
        private const string ReportsV3 = 
            @"
## Changes
* Breaking: TODO
";
        
        public static OpenApiInfo CreateInfoForApiVersion(string? groupGroupName, ApiDescription groupItem)
        {
            var info = new OpenApiInfo
            {
                Title = "Weather API",
                Version = groupItem.GetApiVersion().ToString(),
                Description = GetDocumentation(groupItem.GetApiVersion())
            };

            if (groupItem.IsDeprecated())
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }

        private static string GetDocumentation(ApiVersion version) =>
            version.Status == "weather"
                ? version.MajorVersion switch
                {
                    1 => WeatherV1,
                    2 => WeatherV2,
                    3 => WeatherV3,
                    _ => WeatherV1
                }
                : version.MajorVersion switch
                {
                    1 => ReportsV1,
                    2 => ReportsV2,
                    3 => ReportsV3,
                    _ => ReportsV1
                };
    }
}