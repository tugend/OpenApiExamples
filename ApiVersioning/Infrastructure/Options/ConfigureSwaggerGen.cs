using System;
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

        public ConfigureSwaggerGen(IApiDescriptionGroupCollectionProvider groupProvider)
        {
            _groupProvider = groupProvider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            var docs = options.SwaggerGeneratorOptions.SwaggerDocs;

            foreach (var group in _groupProvider.ApiDescriptionGroups.Items)
            {
                docs.Add(group.GroupName!, CreateInfoForApiVersion(group));
            }
        }

        private static OpenApiInfo CreateInfoForApiVersion(ApiDescriptionGroup description)
        {
            var groupApiVersion = description.Items[0];

            var info = new OpenApiInfo
            {
                Title = description.GroupName,
                Version = groupApiVersion.GetApiVersion().ToString(),
            };

            if (groupApiVersion.IsDeprecated())
            {
                info.Description += $"{Environment.NewLine}This API version has been deprecated";
            }

            return info;
        }

       
    }
}