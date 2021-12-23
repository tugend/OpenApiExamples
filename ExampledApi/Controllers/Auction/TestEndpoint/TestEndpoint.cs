using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using WebApi.Infrastructure.Swagger.Examples;

namespace ExampledApi.Controllers.Auction.TestEndpoint
{
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/v1/food-stock/auctions")]  
    public class TestEndpoint
    {
        // [SwaggerRequestExample(typeof(TestRequest2), typeof(TestRequest2ExampleProvider))] // not neccessary
        [HttpPut("items")]
        public ActionResult<TestResponse> PutBid(TestRequest2 request)
        {
            return new TestResponse("foo", "bar", 1, 2);
        }
    }

    public class TestResponse
    {
        /// <example>Men's basketball shoes</example>
        public string? SomeNullableReferenceType { get; }
        public string SomeNonNullableReferenceType { get; }
        public int? SomeNullableValueType  { get; }
        public int SomeNonNullableValueType { get; }

        public TestResponse(string? someNullableReferenceType, string someNonNullableReferenceType, int someNullableValueType, int? someNonNullableValueType)
        {
            SomeNullableReferenceType = someNullableReferenceType;
            SomeNonNullableReferenceType = someNonNullableReferenceType;
            SomeNullableValueType = someNonNullableValueType;
            SomeNonNullableValueType = someNullableValueType;
        }
    }
    
    // https://stackoverflow.com/questions/29655502/json-net-require-all-properties-on-deserialization/29660550
    public record TestRequest2
    {
        // TODO: meh... we're allowed to cast this to null anyway!
        public string? SomeNullableReferenceType { get; }
     
        /// <example>Men's basketball shoes</example>
        /// TODO: either use  example or AddSwaggerExamplesFromAssemblyOf
        public string SomeNonNullableReferenceType { get; }
        public int? SomeNullableValueType  { get; }
        public int SomeNonNullableValueType { get; }

        public TestRequest2(string? someNullableReferenceType, string someNonNullableReferenceType, int? someNullableValueType, int someNonNullableValueType)
        {
            SomeNullableReferenceType = someNullableReferenceType;
            SomeNonNullableReferenceType = someNonNullableReferenceType;
            SomeNullableValueType = someNullableValueType;
            SomeNonNullableValueType = someNonNullableValueType;
        }
    }
}