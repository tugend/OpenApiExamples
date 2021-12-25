using System;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace ExampledApi.Controllers.Auction.TestEndpoint
{
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/v1/test")]  
    public class TestEndpoint
    {
        [HttpPost("items")]
        public ActionResult<TestResponse> Post(Guid itemId, TestRequest request)
        {
            return new TestResponse("foo", "bar", 100, 0);
        }
    }
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
    
    [PublicAPI]
    public record TestRequest
    {
        public string? SomeNullableReferenceType { get; init; }
        public string SomeNonNullableReferenceType { get; init; } = null!;
        public int? SomeNullableValueType  { get; init; }
        public int SomeNonNullableValueType { get; init; }
    }
}