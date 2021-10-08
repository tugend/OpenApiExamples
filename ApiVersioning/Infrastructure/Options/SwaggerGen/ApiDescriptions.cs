using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

namespace ApiVersioning.Infrastructure.Options.SwaggerGen
{
    /// <summary>
    /// The place to update the textual API documentation.
    /// </summary>
    public static class ApiDescriptions
    {
        private const string V1 = 
@"
## Initial API
* Add: Initial version of `GET /forecast`, will be removed after 2021 December.
";
        private const string V2 = 
@"
## Changes
* Breaking: `GET /forecast` now requires date range to be specified.
";
        private const string V3 = 
@"
## Changes
* Breaking: Major format changes for forecast data.
* Add: Endpoint for fetching detailed forecast reports `GET /reports`
";
        
        public static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Title = "Weather API",
                Version = description.ApiVersion.ToString(),
                Description = GetDocumentation(description.ApiVersion)
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }

        private static string GetDocumentation(ApiVersion apiVersionMajorVersion) =>
            apiVersionMajorVersion.MajorVersion switch
            {
                1 => V1,
                2 => V2,
                3 => V3,
                _ => V1
            };
    }
}