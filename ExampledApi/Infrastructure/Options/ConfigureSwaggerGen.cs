using System;
using System.IO;
using ExampledApi.Controllers.Infrastructure;
using ExampledApi.Infrastructure.Utils;
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

            // c.ExampleFilters();
        }
    }
}