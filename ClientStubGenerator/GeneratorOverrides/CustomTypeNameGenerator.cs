using System.Collections.Generic;
using NJsonSchema;

namespace ClientStubGenerator.GeneratorOverrides
{
    public class CustomTypeNameGenerator : ITypeNameGenerator
    {
        public string Generate(JsonSchema schema, string typeNameHint, IEnumerable<string> reservedTypeNames)
        {
            // I've set this to contain the partial namespace with '.'
            // but '.' is not valid in the generated output
            return typeNameHint.Replace(".", "");   
        }
    }
}