using JetBrains.Annotations;

namespace ExampledApi.Api.Test
{
    [PublicAPI]
    public record TestRequest
    {
        public string? SomeNullableReferenceType { get; init; }
        public string SomeNonNullableReferenceType { get; init; } = null!;
        public int? SomeNullableValueType  { get; init; }
        public int SomeNonNullableValueType { get; init; }
    }
}