using System;
using System.IO;
using ClientStubGenerator.GeneratorOverrides;
using NSwag;
using NSwag.CodeGeneration;
using NSwag.CodeGeneration.CSharp;

// https://stackoverflow.com/questions/45241177/nswag-namespace-in-model-names
var inputPath = Path.Combine("..", "..", "..", "input", "swagger.json");
var document = await OpenApiDocument.FromFileAsync(inputPath);

var clientSettings = new CSharpClientGeneratorSettings 
{
    OperationNameGenerator = new CustomOperationNameGenerator(), // EndpointClient and TestEndpointClient
    GenerateBaseUrlProperty = false,
    UseBaseUrl = false,
    GeneratePrepareRequestAndProcessResponseAsAsyncMethods = false,
    CSharpGeneratorSettings = 
    {
        Namespace = "ExampledApi",
        GenerateNullableReferenceTypes = true,
        TypeNameGenerator = new CustomTypeNameGenerator()
    }
};

var clientGenerator = new CSharpClientGenerator(document, clientSettings);
Console.WriteLine("Generating client...");
var everything = clientGenerator.GenerateFile(ClientGeneratorOutputType.Full);
// var contracts = clientGenerator.GenerateFile(ClientGeneratorOutputType.Contracts);
// var clients = clientGenerator.GenerateFile(ClientGeneratorOutputType.Implementation);
Console.WriteLine("Generated client");

File.WriteAllText(Path.Combine("..", "..", "..", "Output", "ExampledApi.cs"), everything);
// File.WriteAllText(Path.Combine("..", "..", "..", "Output", "ExampledApiContracts.cs"), contracts);
// File.WriteAllText(Path.Combine("..", "..", "..", "Output", "ExampledApiClients.cs"), clients);