using System.Linq;
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
            foreach (var item in _provider.ApiDescriptionGroups.Items
                .OrderBy(x => x.GroupName)
                .ThenByDescending(x => x.Items[0].GetApiVersion()))
            {
                options.SwaggerEndpoint($"/swagger/{item.GroupName}/swagger.json", item.GroupName);
            }      
        }
    }
}