using System.Globalization;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
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
                var versionGroupName = result
                    .GetApiVersion()
                    .ToString(_options.Value.GroupNameFormat, CultureInfo.CurrentCulture);

                // [ApiExplorerSettings(GroupName="...")] was NOT set so
                // nothing else to do
                if (result.GroupName == versionGroupName)
                {
                    continue;
                }

                // must be using [ApiExplorerSettings(GroupName="...")] so
                // concatenate it with the formatted API version
                result.GroupName = $"{result.GroupName}_{versionGroupName}";
            }
        }
    }
}