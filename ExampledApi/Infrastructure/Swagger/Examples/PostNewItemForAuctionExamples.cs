using System.Collections.Generic;
using ExampledApi.Controllers.Auction.Common;
using ExampledApi.Controllers.Auction.PostNewItemForAuction;
using Swashbuckle.AspNetCore.Filters;

namespace ExampledApi.Swagger.Examples
{
    public class PostNewItemForAuctionExamplesProvider : IMultipleExamplesProvider<Request>
    {
        public IEnumerable<SwaggerExample<Request>> GetExamples()
        {
            return new List<SwaggerExample<Request>>
            {
                SwaggerExample.Create("Expensive Rice Example",
                    new Request
                    {
                        QuantityKg = 1,
                        RiceQuality = RiceQuality.Diamond,
                        SellerId = "clark-and-thomson",
                        SellerName = "Clark and Thomson, Rice Industrialized",
                        MinimumBidDkk = 1000
                    }),
                
                SwaggerExample.Create("Cheap Rice Example",
                    new Request
                    {
                        QuantityKg = 100,
                        RiceQuality = RiceQuality.Iron,
                        SellerId = "100",
                        SellerName = "Cheap stuff overseas A/S",
                        MinimumBidDkk = 10
                    })
            };
        }
    }
}