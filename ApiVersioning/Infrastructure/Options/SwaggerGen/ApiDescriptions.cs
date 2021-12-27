using System.Linq;

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
        
        private const string Default = 
            @"
## TODO
";
        
        public static string GetDocumentation(string groupName, string version)
        {
            var apiName = groupName
                .Split("_")
                .FirstOrDefault();
            
            // Slightly hacky solution to string match this way here
            return apiName == "weather" 
                ? version switch
                {
                    "1" => WeatherV1,
                    "2" => WeatherV2,
                    "3" => WeatherV3,
                    _ => WeatherV1
                }
                : version switch
                {
                    _ => Default
                };
        }
    }
}