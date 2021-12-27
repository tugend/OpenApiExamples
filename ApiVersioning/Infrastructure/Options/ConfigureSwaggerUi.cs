using System.Linq;
using ApiVersioning.Infrastructure.Options.SwaggerGen;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace ApiVersioning.Infrastructure.Options
{
    public class ConfigureSwaggerUi : IConfigureOptions<SwaggerUIOptions>
    {
        private readonly IApiDescriptionGroupCollectionProvider _provider;

        public ConfigureSwaggerUi(IApiDescriptionGroupCollectionProvider provider) => _provider = provider;
        
        public void Configure(SwaggerUIOptions options)
        {
            var endpointDescriptions = _provider.ApiDescriptionGroups.Items;
            
            // Order alphabetically
            foreach (var item in endpointDescriptions.OrderBy(x => x.GroupName))
            {
                // Must match urlNameSwaggerJsonDocumentIsPublishedAt from ConfigureSwaggerGen
                var whereToFindSwaggerJson = $"/swagger/{item.GroupName}/swagger.json"; 
                
                var documentSelectorDropdownName = TitleFormatter.FormatSwaggerGroupNameForDisplay(item.GroupName);

                options.SwaggerEndpoint(whereToFindSwaggerJson, documentSelectorDropdownName);
            }
        }
    }
}