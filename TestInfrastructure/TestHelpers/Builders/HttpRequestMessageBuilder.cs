using System.Net.Http;
using System.Net.Http.Json;

namespace Tests.TestHelpers.Builders
{
    public class HttpRequestMessageBuilder
    {
        private readonly HttpMethod _method;
        private readonly string _url;
        private readonly object _body;

        public HttpRequestMessageBuilder(HttpMethod method, string url, object body = null)
        {
            _method = method;
            _url = url;
            _body = body;
        }

        public static HttpRequestMessageBuilder Create(HttpMethod method, string url, object body = null) => 
            new(method, url, body);
        
        public HttpRequestMessage Build()
        {
            return new(_method, _url) { Content = JsonContent.Create(_body) };
        }
    }
}