using System;
using ExampledApi.Controllers.Auction.Common;
using JetBrains.Annotations;

namespace ExampledApi.Controllers.Auction.GetAuctionedItems
{
    [PublicAPI]
    public record Response
    {
        /// <example>f72c083d-6df7-4130-8c87-0662186eae3f</example>
        public Guid ItemId { get; }
        
        /// <example>999</example>
        public int? MinimumBidDkk { get; }
        
        /// <example>100</example>
        public decimal QuantityKg { get; }
        
        /// <example>Iron</example>
        public RiceQuality RiceQuality { get; }

        public Response(Guid itemId, int? minimumBidDkk, decimal quantityKg, RiceQuality riceQuality)
        {
            ItemId = itemId;
            MinimumBidDkk = minimumBidDkk;
            QuantityKg = quantityKg;
            RiceQuality = riceQuality;
        }
    }
}