using ExampledApi.Controllers.Auction.TestEndpoint;
using Swashbuckle.AspNetCore.Filters;

namespace WebApi.Infrastructure.Swagger.Examples
{
    // public class CreatePayment : IExamplesProvider<Controllers.CreatePaymentRequestV1>
    // {
    //
    //     public Controllers.CreatePaymentRequestV1 GetExamples()
    //     {
    //         return new(200);
    //     }
    //     
    //     // public Controllers.CreatePaymentRequestV1 GetExamples()
    //     // {
    //     //     return new(200, Guid.NewGuid().ToString(), "everyday purchase");
    //     // }
    // }
    
    public class TestRequest2ExampleProvider : IExamplesProvider<TestRequest2> // TODO: remove the other packages
    {
    
        public TestRequest2 GetExamples()
        {
            return new TestRequest2("Some non nullable string", "foobar", 123, 1233);
        }
        
        // public Controllers.CreatePaymentRequestV1 GetExamples()
        // {
        //     return new(200, Guid.NewGuid().ToString(), "everyday purchase");
        // }
    }
}