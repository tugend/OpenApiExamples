using System;
using System.IO;
using NSwag;
using NSwag.CodeGeneration.CSharp;
using NSwag.CodeGeneration.OperationNameGenerators;

var document = await OpenApiDocument.FromFileAsync(@"C:\Users\tugen\Documents\GitHub\OpenApiExamples\ClientStubGenerator\swagger.json");
var clientSettings = new CSharpClientGeneratorSettings 
{
    ClassName = "ExampledApiClient",
    OperationNameGenerator = new SingleClientFromPathSegmentsOperationNameGenerator(),
    CSharpGeneratorSettings = 
    {
        Namespace = "ExampledApi",
        GenerateNullableReferenceTypes = true,
        // GenerateOptionalPropertiesAsNullable = true
    }
};

var clientGenerator = new CSharpClientGenerator(document, clientSettings);
var code = clientGenerator.GenerateFile();

File.WriteAllText(@"C:\Users\tugen\Documents\GitHub\OpenApiExamples\ClientStubGenerator\Output.cs", code);
Console.Write(code);