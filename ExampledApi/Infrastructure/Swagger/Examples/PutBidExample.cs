using ExampledApi.Controllers.Auction.PutBid;
using Swashbuckle.AspNetCore.Filters;
using static ExampledApi.Domain.FakeHelper;

namespace ExampledApi.Swagger.Examples
{
    public class PutBidExampleProvider : IExamplesProvider<Request> // TODO: remove the other packages
    {
        public Request GetExamples()
        {
            return new Request
            {
                AmountDkk = Pick(100, 200, 300)
            };
        }
    }
}