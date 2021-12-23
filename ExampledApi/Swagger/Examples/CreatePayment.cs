using System;
using Swashbuckle.AspNetCore.Filters;

namespace WebApi.Infrastructure.Swagger.Examples
{
    public class CreatePayment : IExamplesProvider<Controllers.CreatePaymentRequestV1>
    {
        public Controllers.CreatePaymentRequestV1 GetExamples()
        {
            return new(200);
        }
        
        // public Controllers.CreatePaymentRequestV1 GetExamples()
        // {
        //     return new(200, Guid.NewGuid().ToString(), "everyday purchase");
        // }
    }
}