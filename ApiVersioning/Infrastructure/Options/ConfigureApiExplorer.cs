using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;

namespace ApiVersioning.Infrastructure.Options
{
    /// <summary>
    /// Controls version format and auto updates routes to include the specified versions et. al.
    /// </summary>
    public class ConfigureApiExplorer : IConfigureOptions<ApiExplorerOptions>
    {
        public void Configure(ApiExplorerOptions options)
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        }
    }
}