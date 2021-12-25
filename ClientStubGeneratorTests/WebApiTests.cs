using System;
using System.Net.Http;
using ExampledApi;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace ClientStubGeneratorTests
{
    public class WebApiTests: IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public WebApiTests(WebApplicationFactory<Startup> fixture) => _client = fixture
            .WithWebHostBuilder(_ => { })
            .CreateClient();
    
        [Fact]
        public async void Generated_Client_Can_Call_Api()
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
    }
}