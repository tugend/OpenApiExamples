using System;
using ExampledApi.Controllers.Auction.Common;
using ExampledApi.Controllers.Auction.GetAuctionedItems;
using static ExampledApi.Domain.FakeHelper;

namespace ExampledApi.Domain
{
    public static class FakeAuctionItemGenerator
    {
        public static Response FakeAuctionedFoodStockResponse() =>
            new(
                Guid.NewGuid(),
                100,
                Pick(100, 200, 300, 400, 500, 600, 700, 800, 900),
                Pick(Enum.GetValues<RiceQuality>()));
    }
}