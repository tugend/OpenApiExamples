using System;
using System.Net.Http;
using ExampledApi;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using static Microsoft.AspNetCore.Http.StatusCodes;
using static Newtonsoft.Json.JsonConvert;

namespace ClientStubGeneratorTests
{
    public class WebApiTests: IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public WebApiTests(WebApplicationFactory<Startup> fixture) => _client = fixture
            .WithWebHostBuilder(_ => { })
            .CreateClient();
    
        [Fact]
        public async void PostItemForAuction()
        {
            // Remember
            var client = new AuctionClient(_client);
            
            var result = await client.PostItemForAuctionAsync(Guid.NewGuid(), new PostNewItemForAuctionRequest
            {
               QuantityKg = 1,
               RiceQuality = CommonRiceQuality.Bronze,
               SellerId = "seller-id:2001",
               SellerName = "Mr. Foo Trading",
               MinimumBidDkk = 155
            });
            
            Assert.Equal("seller-id:2001", result.SellerId);
            Assert.Equal("Mr. Foo Trading", result.SellerName);
        }
        
        [Fact]
        public async void GetAuctionedItems_Given_Unknown_Auction()
        {
            // Remember
            var client = new AuctionClient(_client);

            var error = await Assert.ThrowsAsync<ApiException>(() => client.GetAuctionedItemsAsync(Guid.NewGuid()));

            Assert.Equal(Status404NotFound, error.StatusCode);
            Assert.Equal("Unknown auction id", DeserializeObject<Error>(error.Response!)!.Message);
        }
    }

    [PublicAPI]
    public record Error
    {
        public string Message { get; init; }
    }
}