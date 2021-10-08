using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Options;

namespace ApiVersioning.Infrastructure.Options
{
    /// <summary>
    /// Controls the default api version et. al.
    /// </summary>
    public class ConfigureApiVersioning : IConfigureOptions<ApiVersioningOptions>
    {
        public void Configure(ApiVersioningOptions options)
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true; 
        }   
    }
}