using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ApiVersioning;
using ApiVersioning.Controllers.EndpointModels.Forecast.CurrentVersion;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Mvc.Versioning;
using Tests.TestHelpers.Builders;
using Tests.TestHelpers.Extensions;
using Xunit;

namespace ApiVersioningTests
{
    public class WebApiTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public WebApiTests(WebApplicationFactory<Startup> fixture) => _client = fixture
            .WithWebHostBuilder(_ => { })
            .CreateClient();

        [Theory]
        [InlineData("api/weather/forecasts")]
        [InlineData("api/v1/weather/forecasts")]
        [InlineData("api/v2/weather/forecasts")]
        public async Task ForecastResourcesShouldBeAvailable(string path)
        {
            // Arrange
            var message = HttpRequestMessageBuilder
                .Create(HttpMethod.Get, path)
                .Build();

            // ACT
            await _client
                .SendAsync(message)
                .Read()
                .AssertStatusCode(HttpStatusCode.OK);
        }
        
        [Theory]
        [InlineData("api/v3/weather/forecasts")]
        public async Task RangedForecastResourcesShouldBeAvailable(string path)
        {
            // Arrange
            var message = HttpRequestMessageBuilder
                .Create(HttpMethod.Get, path, new ForecastRange
                {
                    From = DateTime.Now,
                    To = DateTime.Now.AddDays(2)
                })
                .Build();

            // ACT
            await _client
                .SendAsync(message)
                .AssertStatusCode(HttpStatusCode.OK);
        }
        
        [Theory]
        [InlineData("api/v2/reports")]
        [InlineData("api/v3/reports")]
        public async Task ReportResourcesShouldBeAvailable(string path)
        {
            // Arrange
            var message = HttpRequestMessageBuilder
                .Create(HttpMethod.Get, path,new ForecastRange
                {
                    From = DateTime.Now,
                    To = DateTime.Now.AddDays(2)
                })
                .Build();

            // ACT
            await _client
                .SendAsync(message)
                .AssertStatusCode(HttpStatusCode.OK);
        }
        
        [Theory]
        [InlineData("api/reports")]
        public async Task Un_VersionedReportResourcesShouldNotBeAvailable(string path)
        {
            // Arrange
            var message = HttpRequestMessageBuilder
                .Create(HttpMethod.Get, path)
                .Build();

            // ACT
            await _client
                .SendAsync(message)
                .AssertStatusCode(HttpStatusCode.NotFound);
        }
        
        [Theory]
        [InlineData("api/v1/reports")]
        public async Task NonSupportedVersionedReportResourcesShouldNotBeAvailable(string path)
        {
            // Arrange
            var message = HttpRequestMessageBuilder
                .Create(HttpMethod.Get, path)
                .Build();

            // ACT
            var response = await _client
                .SendAsync(message)
                .AssertStatusCode(HttpStatusCode.BadRequest)
                .Deserialize<ErrorResponse>();
            
            Assert.Equal(ErrorCodes.UnsupportedApiVersion, response.Error.Code);
            Assert.Contains("does not support the API version", response.Error.Message);
        }
        
        // Yeh.. this is a bit confusing.
        // Aspnet-api-versioning seems to return a non-public custom error response 'OneApiError'.
        // https://github.com/dotnet/aspnet-api-versioning/search?l=C%23&q=OneApiError
        private class ErrorResponse
        {
            public ErrorResponse(Error error)
            {
                Error = error;
            }

            public Error Error { get; }
        }
        
        private class Error
        {
            public Error(string code, string message)
            {
                Code = code;
                Message = message;
            }

            public string Code { get; }
            public string Message { get; }
        }
    }
}