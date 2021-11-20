using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace ApiVersioning.Infrastructure.Options
{
    public class ConfigureSwaggerUi : IConfigureOptions<SwaggerUIOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerUi(IApiVersionDescriptionProvider provider) => _provider = provider;
        
        public void Configure(SwaggerUIOptions options)
        {
            // Generate a web page at /{RoutePrefix}/index.html
            // that display an api per api description.
            // 
            // Assumes per api description that the associated open api document
            // can be found at {url}. This is usually set in SwaggerOptions.
            //
            // The name of each description as presented in the drop down
            // selector is {documentName}.
            options.RoutePrefix = "swagger";
            
            foreach (var description in _provider.ApiVersionDescriptions.OrderBy(x => x.GroupName))
            {
                var url = $"/swagger/{description.GroupName}/swagger.json";
                var documentName = description.GroupName;
                options.SwaggerEndpoint(url,  documentName);
            }        
        }
    }
}