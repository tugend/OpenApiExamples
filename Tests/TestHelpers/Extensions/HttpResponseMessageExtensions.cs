using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace Tests.TestHelpers.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<HttpResponseMessage> AssertStatusCode(this Task<HttpResponseMessage> pendingResponse, HttpStatusCode expectedCode)
        {
            var response = await pendingResponse;
            
            var statusCode = response.StatusCode;

            Assert.Equal(expectedCode, statusCode);
            
            return response;
        }

        public static async Task<T> Deserialize<T>(this Task<HttpResponseMessage> pendingResponse)
        {
            var content = await pendingResponse.ReadContent();
            return JsonConvert.DeserializeObject<T>(content);
        }
        
        public static async Task<string> ReadContent(this Task<HttpResponseMessage> pendingResponse)
        {
            var response = await pendingResponse;
            
            return await response.Content.ReadAsStringAsync();
        }
    }
}