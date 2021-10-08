using ApiVersioning.Infrastructure.Options.SwaggerGen;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiVersioning.Infrastructure.Options
{
    /// <summary>
    /// Generate a swagger document per API version 
    /// </summary>
    public class ConfigureSwaggerGen : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerGen(IApiVersionDescriptionProvider provider) => _provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, ApiDescriptions.CreateInfoForApiVersion(description));
            }

            options.DocumentFilter<RemoveDefaultApiVersionRouteDocumentFilter>();
        }

        // TODO: Source: https://stackoverflow.com/questions/58834430/c-sharp-net-core-swagger-trying-to-use-multiple-api-versions-but-all-end-point
    }
}