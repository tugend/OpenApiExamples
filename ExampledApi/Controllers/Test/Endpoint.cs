using System;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace ExampledApi.Controllers.Test
{
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