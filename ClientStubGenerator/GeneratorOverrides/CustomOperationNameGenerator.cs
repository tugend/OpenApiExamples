using System;
using System.Linq;
using NJsonSchema;
using NSwag;
using NSwag.CodeGeneration.OperationNameGenerators;

public class CustomOperationNameGenerator : IOperationNameGenerator
{
    /// <summary>Gets a value indicating whether the generator supports multiple client classes.</summary>
    public bool SupportsMultipleClients => true;

    public virtual string GetClientName(OpenApiDocument document, string path, string httpMethod, OpenApiOperation operation)
    {
        return ConversionUtilities.ConvertToUpperCamelCase(operation.Tags.FirstOrDefault(), false);
    }

    public virtual string GetOperationName(OpenApiDocument document, string path, string httpMethod, OpenApiOperation operation)
    {
        var methodSegment = ConversionUtilities.ConvertToUpperCamelCase(httpMethod, true);
        var pathSegment = ConversionUtilities.ConvertToUpperCamelCase(ConvertPathToName(path), true);
        // var fakeNamespace = ConvertToUpperCamelCase(operation.Tags.FirstOrDefault(), true);
        // return methodSegment + pathSegment;
        return operation.OperationId;
    }

    private static string ConvertPathToName(string path)
    {
        return path
            .Split('/')
            .Reverse()
            .FirstOrDefault() ?? throw new Exception("TODO");
    }
}