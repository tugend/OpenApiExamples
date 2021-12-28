using System;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Options;

namespace ApiVersioning.Infrastructure.Options.SwaggerGen
{
    public class SubgroupDescriptionProvider : IApiDescriptionProvider
    {
        private readonly IOptions<ApiExplorerOptions> _options;

        public SubgroupDescriptionProvider(IOptions<ApiExplorerOptions> options)
            => _options = options;

        // Execute after DefaultApiVersionDescriptionProvider.OnProvidersExecuted
        public int Order => -1;

        public void OnProvidersExecuting(ApiDescriptionProviderContext context) { }

        public void OnProvidersExecuted(ApiDescriptionProviderContext context)
        {
            foreach (var result in context.Results)
            {
                var versionName = result
                    .GetApiVersion()
                    .ToString(_options.Value.GroupNameFormat);

                var controllerName = (result.ActionDescriptor as ControllerActionDescriptor)?
                    .ControllerName
                    .ToLowerInvariant()
                    ?? throw new Exception("TODO");
            
                result.GroupName = $"{controllerName}_{versionName}";
            }
        }
    }
}