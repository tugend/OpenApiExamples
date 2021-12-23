using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
    public class TestRequest2
    {
        public string? SomeNullableReferenceType { get; set; }
        public string SomeNonNullableReferenceType  { get; set; }
        
        public int? SomeNullableValueType  { get; set; }
        public int SomeNonNullableValueType { get; set; }
    }
}