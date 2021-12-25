using JetBrains.Annotations;

namespace ExampledApi.Api.Test
{
    [PublicAPI]
    public class TestResponse
    {
        public string? SomeNullableReferenceType { get; }
        public string SomeNonNullableReferenceType { get; }
        public int? SomeNullableValueType  { get; }
        public int SomeNonNullableValueType { get; }

        public TestResponse(string? someNullableReferenceType, string someNonNullableReferenceType, int? someNullableValueType, int someNonNullableValueType)
        {
            SomeNullableReferenceType = someNullableReferenceType;
            SomeNonNullableReferenceType = someNonNullableReferenceType;
            SomeNullableValueType = someNullableValueType;
            SomeNonNullableValueType = someNonNullableValueType;
        }
    }
}