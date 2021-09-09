using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using EndpointVersioning;
using EndpointVersioning.Controllers.EndpointModels.Forecast.V2;
using EndpointVersioning.Domain.Forecast.ForecasterModels;
using Microsoft.AspNetCore.Mvc.Testing;
using SecureWebApi.Tests.TestHelpers.Builders;
using SecureWebApi.Tests.TestHelpers.Extensions;
using Xunit;

namespace SecureWebApi.Tests.Endpoints.Users.Restricted
{
    public class WebApiTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public WebApiTests(WebApplicationFactory<Startup> fixture) => _client = fixture
            .WithWebHostBuilder(x => { })
            .CreateClient();

        [Fact]
        public async Task GetForecastV1()
        {
            // Arrange
            var message = HttpRequestMessageBuilder
                .Create(HttpMethod.Get, "api/weather/forecast/v1")
                .Build();

            // ACT
            var forecasts = (await _client
                .SendAsync(message)
                .AssertStatusCode(HttpStatusCode.OK)
                .Deserialize<IEnumerable<WeatherForecast>>())
                .ToList();
            
            // ASSERT
            Assert.NotEmpty(forecasts);
            foreach (var forecast in forecasts)
            {
                Assert.NotEqual(default, forecast.Date);
                Assert.NotEqual(default, forecast.TemperatureC);
                Assert.NotEqual(default, forecast.TemperatureF);
                Assert.NotNull(forecast.Summary);
            }
        }
        
        [Fact]
        public async Task GetForecastV2()
        {
            // Arrange
            var message = HttpRequestMessageBuilder
                .Create(HttpMethod.Get, "api/weather/forecast/v2", new ForecastV2Request { From = DateTime.Today, To = DateTime.Today.AddDays(5) })
                .Build();

            // ACT
            var forecasts = (await _client
                    .SendAsync(message)
                    .AssertStatusCode(HttpStatusCode.OK)
                    .Deserialize<IEnumerable<WeatherForecast>>())
                .ToList();
            
            // ASSERT
            Assert.NotEmpty(forecasts);
            foreach (var forecast in forecasts)
            {
                Assert.NotEqual(default, forecast.Date);
                Assert.NotEqual(default, forecast.TemperatureC);
                Assert.NotEqual(default, forecast.TemperatureF);
                Assert.NotNull(forecast.Summary);
            }
        }
    }
}