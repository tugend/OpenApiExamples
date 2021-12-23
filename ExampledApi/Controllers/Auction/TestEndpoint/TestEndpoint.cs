using Microsoft.AspNetCore.Mvc;

namespace ExampledApi.Controllers.Auction.TestEndpoint
{
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/v1/food-stock/auctions")]  
    public class TestEndpoint
    {
        [HttpPut("items")]
        public ActionResult PutBid(TestRequest2 request)
        {
            return new OkResult();
        }
    }

    public class TestRequest
    {
        public readonly string? SomeNullableReferenceType;
        public readonly string SomeNonNullableReferenceType;
        public readonly int SomeNullableValueType;
        public readonly int? SomeNonNullableValueType;

        public TestRequest(string? someNullableReferenceType, string someNonNullableReferenceType, int someNullableValueType, int? someNonNullableValueType)
        {
            SomeNullableReferenceType = someNullableReferenceType;
            SomeNonNullableReferenceType = someNonNullableReferenceType;
            SomeNullableValueType = someNullableValueType;
            SomeNonNullableValueType = someNonNullableValueType;
        }
    }
    
    // https://stackoverflow.com/questions/29655502/json-net-require-all-properties-on-deserialization/29660550
    public record TestRequest2
    {
        // TODO: meh... we're allowed to cast this to null anyway!
        public string? SomeNullableReferenceType { get; }
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