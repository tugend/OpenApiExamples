using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace ApiVersioning.Infrastructure.Options
{
    public class ConfigureSwagger : IConfigureOptions<SwaggerOptions>
    {
        public void Configure(SwaggerOptions options)
        {
            options.RouteTemplate = "/swagger/{documentName}/swagger.json";
        }
    }
}