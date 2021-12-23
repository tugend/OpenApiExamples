using System;
using System.Linq;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ExampledApi.Controllers.Infrastructure
{
    public class AddSwaggerRequiredSchemaFilter : ISchemaFilter
    {
        /// <summary>
        /// Make all properties required, non-nullable unless otherwise specified?
        /// </summary>
        /// https://newbedev.com/how-to-configure-swashbuckle-to-ignore-property-on-model
        /// https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/2036
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            // context.Type.GetRuntimeFields().Where(x => x.CustomAttributes.Any(data =>  data == System.Runtime.CompilerServices.NullableAttribute))
            var nullableReferenceTypeHacks = context.Type.GetMembers()
                .Where(member => member.CustomAttributes.Any(attr => attr.AttributeType.Name == "NullableContextAttribute"))
                .Select(x => x.Name);
            if (schema.Properties == null)
            {
                return;
            }
            
            const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            var memberList = context.Type
                .GetFields(bindingFlags)
                .Cast<MemberInfo>()
                .Concat(context.Type.GetProperties(bindingFlags))
                .ToList();
            
            var matchedList = memberList
                .Where(m => m.GetCustomAttribute<OptionalAttribute>() != null || m.CustomAttributes.Any(attr => attr.AttributeType.Name == "NullableAttribute"))
                .Select(m => m.Name.ToLower())
                .ToList();
            // TODO: use assignable to Nullable generic instead

            // https://newbedev.com/how-to-configure-swashbuckle-to-ignore-property-on-model
            foreach (var (key, value) in schema.Properties.Where(x => !matchedList.Contains(x.Key)))
            {
                if (!value.Nullable)
                {
                    schema.Required.Add(key);
                }
                // value.Nullable = false;
            }
            
            // foreach (var (key, value) in schema.Properties)
            // {
            //     value.Nullable = false;
            // }
            
            // if (context.MemberInfo?.GetCustomAttribute<OptionalAttribute>() == null) return;
            //
            // // TODO: fix naming
            // var optionalMemberKey = context.MemberInfo.Name.ToLower();
            //
            // // if (schema.Properties != null)
            // // {
            // foreach (var (key, value) in schema.Properties)
            // {
            //     if (value.GetType().GetProperties().Any(x => x.GetCustomAttribute<OptionalAttribute>() != null))
            //         continue;
            //
            //     if (key == optionalMemberKey) continue;
            //     
            //     // make values required i.e. must be included in the request (not used for responses?
            //     // for some reason, still remains nullable!
            //     schema.Required.Add(key);
            //     value.Nullable = false;
            // }
            // }    

            // https://stackoverflow.com/questions/46576234/swashbuckle-make-non-nullable-properties-required

            // https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/1346
            // if (schema.Properties == null) {
            //     return;
            // }
            //
            // var requiredButNullableProperties = schema
            //     .Properties
            //     .Where(x => x.Value.Nullable && schema.Required.Contains(x.Key))
            //     .ToList();
            //
            // foreach (var property in requiredButNullableProperties) {
            //     property.Value.Nullable = false;
            // }
        }
    }
}