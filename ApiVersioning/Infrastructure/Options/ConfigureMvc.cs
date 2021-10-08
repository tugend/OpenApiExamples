using ApiVersioning.Infrastructure.Options.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ApiVersioning.Infrastructure.Options
{
    public class ConfigureMvc : IConfigureOptions<MvcOptions>
    {
        public void Configure(MvcOptions options)
        {
            options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
        }
    }
}