using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ExampledApi.Controllers.Auction.Common;
using ExampledApi.Controllers.Infrastructure;

namespace ExampledApi.Controllers.Auction.GetAuctionedItems
{
    public class Response
    {
        /// <summary>
        /// -
        /// </summary>
        [Required]
        public Guid ItemId { get; }
        
        /// <summary>
        /// -
        /// </summary>
        public int? MinimumBidDkk { get; }
        
        /// <summary>
        /// -
        /// </summary>
        public decimal QuantityKg { get; }
        
        /// <summary>
        /// -
        /// </summary>
        [Required] // TODO: make this default??
        public RiceQuality RiceQuality { get; }

        public Response(Guid itemId, int minimumBidDkk, decimal quantityKg, RiceQuality riceQuality)
        {
            ItemId = itemId;
            MinimumBidDkk = minimumBidDkk;
            QuantityKg = quantityKg;
            RiceQuality = riceQuality;
        }
    }
}