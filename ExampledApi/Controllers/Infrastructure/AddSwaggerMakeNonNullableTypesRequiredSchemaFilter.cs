using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ExampledApi.Controllers.Infrastructure
{
    public class AddSwaggerMakeNonNullableTypesRequiredSchemaFilter : ISchemaFilter
    {
        /// <summary>
        /// Make all non-nullable properties required
        /// </summary>
        /// https://newbedev.com/how-to-configure-swashbuckle-to-ignore-property-on-model
        /// https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/2036
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema.Properties == null)
            {
                return;
            }
            // https://newbedev.com/how-to-configure-swashbuckle-to-ignore-property-on-model
            foreach (var (key, value) in schema.Properties.Where(x => !x.Value.Nullable))
            {
                schema.Required.Add(key);
            }
        }
    }
}