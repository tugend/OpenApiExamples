using System;
using System.Net.Http;
using ExampledApi;
using Xunit;

namespace ClientStubGeneratorTests
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            var client = new ExampledApiClient("https://localhost:5001/", new HttpClient());
            var result = await client.ApiV1FoodStockAuctionsAuctionItemsPutAsync(Guid.NewGuid(), Guid.NewGuid().ToString(), new TestRequest2
            {
                SomeNullableReferenceType = "foo", // TODO: this is the wrong type
                SomeNullableValueType = 2,
                SomeNonNullableReferenceType = "bar",
                SomeNonNullableValueType = 4
            });
        
            Assert.Equal("foo", result.SomeNullableReferenceType);
        }
    }
}