using System;
using System.Linq;
using ApiVersioning.Infrastructure.Options.SwaggerGen;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiVersioning.Infrastructure.Options
{
    /// <summary>
    /// Generate a swagger document per API version 
    /// </summary>
    public class ConfigureSwaggerGen : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiDescriptionGroupCollectionProvider _groupProvider;

        public ConfigureSwaggerGen(IApiDescriptionGroupCollectionProvider groupProvider) => _groupProvider = groupProvider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var group in _groupProvider.ApiDescriptionGroups.Items)
            {
                var linkToOpenApiJsonDocument = group.GroupName!;
                options.SwaggerGeneratorOptions.SwaggerDocs.Add(linkToOpenApiJsonDocument, CreateInfoForApiVersion(group));
            }
            
            options.DocumentFilter<RemoveDefaultApiVersionRouteDocumentFilter>();
        }
        
        public static OpenApiInfo CreateInfoForApiVersion(ApiDescriptionGroup endpointDescription)
        {
            // Can contain both no versioned and versioned endpoint
            // but values should be the same
            var apiVersion = endpointDescription
                .Items
                .Select(x => x.GetApiVersion().ToString()) 
                .Distinct()
                .Single();

            var isDeprecated = endpointDescription
                .Items
                .Select(x => x.IsDeprecated())
                .Distinct()
                .Single();
            
            var info = new OpenApiInfo
            {
                Title = TitleFormatter.FormatSwaggerGroupNameForDisplay(endpointDescription.GroupName), // As defined by [ApiExplorerSettings(GroupName = "Weather")]
                Version = apiVersion, // As defined by [ApiVersion("1")]
                Description = ApiDescriptions.GetDocumentation(endpointDescription.GroupName!, apiVersion)
            };

            if (isDeprecated)
            {
                info.Description += $"{Environment.NewLine}This API version has been deprecated";
            }

            return info;
        }
    }
}