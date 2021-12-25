using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using ExampledApi.Api.Infrastructure;
using ExampledApi.Infrastructure.Utils;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ExampledApi.Infrastructure.Options
{
    public class ConfigureSwaggerGen  : IConfigureOptions<SwaggerGenOptions>
    {
        public void Configure(SwaggerGenOptions c)
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Auction API", 
                Version = "v1",
                Description = "The set of supported endpoints for integrating with the amazing FOOBAR auction site®"
            });
                
            // Toggle xml comments in output for swagger documentation
            var xmlFilename = $"{typeof(Program).Assembly.GetName().Name}.xml";
            c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
                
            // Use limited namespacing
            c.CustomSchemaIds(x => x.FullName?.StripUntil('.', 3));

            // https://stackoverflow.com/questions/46576234/swashbuckle-make-non-nullable-properties-required
            c.SupportNonNullableReferenceTypes(); // Sets Nullable flags appropriately.              
            c.SchemaFilter<MakeNonNullableTypesRequiredSchemaFilter>();
            
            c.CustomOperationIds(api =>
            {
                if (api.ActionDescriptor is ControllerActionDescriptor cad)
                {
                    return cad.ActionName;
                }
                throw new Exception("TODO");
            });
            
            c.TagActionsBy(api =>
            {
                if (api.ActionDescriptor is ControllerActionDescriptor cad)
                    return new[]
                    {
                        cad.EndpointMetadata
                            .Where(x => x is DisplayNameAttribute)
                            .Cast<DisplayNameAttribute>()
                            .LastOrDefault()?
                            .DisplayName
                            ?? cad.ControllerName
                    };
                
                throw new Exception("TODO");
            });
            // c.ExampleFilters();
        }
    }
}