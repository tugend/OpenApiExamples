using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ExampledApi.Controllers.Infrastructure
{
    public class MakeNonNullableTypesRequiredSchemaFilter : ISchemaFilter
    {
        /// <summary>
        /// Make all non-nullable properties required.
        /// </summary>
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema.Properties == null)
            {
                return;
            }
            foreach (var (key, value) in schema.Properties.Where(x => !x.Value.Nullable))
            {
                schema.Required.Add(key);
            }
        }
    }
}