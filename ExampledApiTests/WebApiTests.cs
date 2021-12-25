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
        public async Task Ok__Given__All_Values_Defined()
        {
            var message = CreateMessage(new
            {
                SomeNonNullableReferenceType = "something",
                SomeNonNullableValueType = 5,
                SomeNullableReferenceType = "anotherSomething",
                SomeNullableValueType = 7
            });
            
            await _client
                .SendAsync(message)
                .AssertStatusCode(HttpStatusCode.OK);
        }
        
        [Fact]
        public async Task Ok__Given__Missing_Nullable_Values()
        {
            var message = CreateMessage(new
            {
                SomeNonNullableReferenceType = "something",
                SomeNonNullableValueType = 5
            });
            
            await _client
                .SendAsync(message)
                .AssertStatusCode(HttpStatusCode.OK);
        }
        
        [Fact]
        public async Task BadRequest__Given__Missing_NonNullableReferenceType()
        {
            var message = CreateMessage(new
            {
                SomeNonNullableValueType = 5
            });
            
            await _client
                .SendAsync(message)
                .Read()
                .AssertStatusCode(HttpStatusCode.BadRequest);
        }
        
        [Fact]
        public async Task BadRequest__Given__Missing_NonNullableValueType()
        {
            var message = CreateMessage(new
            {
                SomeNonNullableReferenceType = "something"
            });
            
            await _client
                .SendAsync(message)
                .AssertStatusCode(HttpStatusCode.BadRequest);
        }
        
        [Fact]
        public async Task BadRequest_Given_Null_NullableTypes()
        {
            var message = CreateMessage(new
            {
                SomeNonNullableReferenceType = "something",
                SomeNonNullableValueType = 5,
                SomeNullableReferenceType = (string?)null,
                SomeNullableValueType = (int?)null
            });
            
            await _client
                .SendAsync(message)
                .AssertStatusCode(HttpStatusCode.OK);
        }
        
        [Fact]
        public async Task BadRequest__Given__Null_NonNullableReferenceType()
        {
            var message = CreateMessage(new
            {
                SomeNonNullableReferenceType = (string?)null,
                SomeNonNullableValueType = 5,
            });
            
            await _client
                .SendAsync(message)
                .AssertStatusCode(HttpStatusCode.BadRequest);
        }
        
        [Fact]
        public async Task BadRequest__Given__Null_NonNullableValueType()
        {
            var message = CreateMessage(new
            {
                SomeNonNullableReferenceType = "something",
                SomeNonNullableValueType = (int?)null,
            });
            
            await _client
                .SendAsync(message)
                .AssertStatusCode(HttpStatusCode.BadRequest);
        }

        private static HttpRequestMessage CreateMessage(object body)
        {
            return HttpRequestMessageBuilder
                .Create(HttpMethod.Post, "api/v1/test", body)
                .Build();
        }
    }
}