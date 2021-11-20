using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiVersioning.Infrastructure.Options.SwaggerGen
{
    /// <summary>
    /// We generate duplicate endpoints, one with a version 'GET /api/v1/forecast' and one without 'GET /api/forecast'.
    ///
    /// In this filter, we remove all endpoints without a version, except for the default version.
    /// I.e. we keep 'GET /api/forecast' but only in the v1 document.
    ///
    /// We also remove the required api-version attribute for the non-versioned endpoints,
    /// which does not make sense when we're applying a default version.
    /// </summary>
    public class RemoveDefaultApiVersionRouteDocumentFilter : IDocumentFilter  
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)  
        {  
            foreach (var apiDescription in context.ApiDescriptions)  
            {  
                var isVersionedApi = apiDescription
                    .ParameterDescriptions  
                    .All(p => p.Name != "api-version");

                var isDefaultVersion = swaggerDoc.Info.Version.Equals("1");

                // remove 'required' api version parameter from un-versioned endpoints
                // from swagger (it's not required by the api since we've set AssumeDefaultVersionWhenUnspecified = true)
                swaggerDoc
                    .Paths
                    .SelectMany(x => x.Value.Operations.Values)
                    .ToList()
                    .ForEach(operation =>
                        operation.Parameters = operation
                            .Parameters
                            .Where(param => param.Name != "api-version")
                            .ToList());

                // api/v2/weather/forecasts
                if (isVersionedApi)
                {
                    continue;
                }
                
                // version 1 api document: api/v1/weather/forecasts and api/weather/forecasts
                if (isDefaultVersion)
                {
                    continue;
                }
                   
                // Remove un-versioned endpoint from generated documents unless
                // it's the initial version. Note: this affects which routes can be called!
                
                // api/weather/forecasts (for v2+ api documents)
                var route = "/" + apiDescription.RelativePath.TrimEnd('/');
                swaggerDoc.Paths.Remove(route);
            }  
        }  
    }  
}