using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ExampledApi
{
    public class MakeNonNullableValueTypesRequiredResolver : DefaultContractResolver
    {
        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            // https://newbedev.com/asp-net-core-require-non-nullable-types
            var contract = base.CreateObjectContract(objectType);
            foreach (var contractProperty in contract.Properties)
            {
                // continue if type is nullable
                if (Nullable.GetUnderlyingType(contractProperty.PropertyType!) != null)
                {
                    continue;
                }

                // if value type, treat as required
                if (contractProperty.PropertyType!.IsValueType)
                {
                    contractProperty.Required = Required.Always;
                }
            }
            return contract;
        }
    }
}