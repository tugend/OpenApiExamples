using System.Linq;
using NJsonSchema;
using NSwag;
using NSwag.CodeGeneration.OperationNameGenerators;

namespace ClientStubGenerator.GeneratorOverrides
{
    public class CustomOperationNameGenerator : IOperationNameGenerator
    {
        /// <summary>Gets a value indicating whether the generator supports multiple client classes.</summary>
        public bool SupportsMultipleClients => true;

        public string GetClientName(OpenApiDocument document, string path, string httpMethod, OpenApiOperation operation)
        {
            // NOTE:
            // Default is controller name
            // but if you want to override it, tags can be used in collaboration with annotating the source with DisplayName
            return ConversionUtilities.ConvertToUpperCamelCase(operation.Tags.FirstOrDefault(), false);
        }

        public string GetOperationName(OpenApiDocument document, string path, string httpMethod, OpenApiOperation operation)
        {
            // Use method name rather than method+path generated name 
            // NOTE: this assumes operation id is set to method name when you generate the input OpenApi document
            return operation.OperationId;
        }
    }
}