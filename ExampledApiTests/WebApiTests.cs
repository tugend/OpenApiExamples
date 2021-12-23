using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ExampledApi;
using Microsoft.AspNetCore.Mvc.Testing;
using Tests.TestHelpers.Builders;
using Tests.TestHelpers.Extensions;
using Xunit;

namespace ExampledApiTests
{
    public class WebApiTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public WebApiTests(WebApplicationFactory<Startup> fixture) => _client = fixture
            .WithWebHostBuilder(_ => { })
            .CreateClient();

        [Fact]
        public async Task GetForecastV1()
        {
            // Arrange
            var message = HttpRequestMessageBuilder
                .Create(HttpMethod.Put, "api/v1/food-stock/auctions/items", new
                {
                    SomeNullableReferenceType = (string?)null,
                    SomeNonNullableReferenceType = "something",
                    SomeNullableValueType = (int?)null,
                    SomeNonNullableValueType = 5
                })
                .Build();

            // ACT
            var (statusCode, content, response) = await _client
                .SendAsync(message)
                .Read();
            
            Assert.Equal(statusCode, HttpStatusCode.OK);
        }
    }
}