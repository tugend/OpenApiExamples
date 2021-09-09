using System;
using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApi.Infrastructure.Swagger
{
    public class RemoveDefaultApiVersionRouteDocumentFilter : IDocumentFilter  
    {  
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)  
        {  
            foreach (var apiDescription in context.ApiDescriptions)  
            {  
                var versionParam = apiDescription
                    .ParameterDescriptions  
                    .FirstOrDefault(p => 
                        p.Name == "api-version" &&  
                        p.Source.Id.Equals("Query", StringComparison.InvariantCultureIgnoreCase));

                // HAAH, keep every thing documented, but let the nasty non-conform unversioned endpoint
                // stay with version 1.0 for ever and until removal!
                if (versionParam == null || swaggerDoc.Info.Version.Contains("1.0")) continue;
                
                var route = "/" + apiDescription.RelativePath.TrimEnd('/');
                swaggerDoc.Paths.Remove(route);
            }  
        }  
    }  
}