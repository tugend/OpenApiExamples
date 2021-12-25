using System.Collections.Generic;
using NJsonSchema;

public class TypeNameGenerator : ITypeNameGenerator
{
    public string Generate(JsonSchema schema, string typeNameHint, IEnumerable<string> reservedTypeNames)
    {
        return typeNameHint.Replace(".", "");   //this contains full namespace (assuming returned in swagger definition)
    }
}