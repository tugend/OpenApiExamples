using System;
using System.ComponentModel;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace ExampledApi.Api.Test
{
    [DisplayName("Test")] // TODO: alternative just use some auto formatting to extract the right name from the namespace?
    [PublicAPI]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/v1/test")]  
    public class TestEndpoint
    {
        [HttpPost]
        public ActionResult<TestResponse> Post(Guid itemId, TestRequest request)
        {
            return new TestResponse("foo", "bar", 100, 0);
        }
    }
}