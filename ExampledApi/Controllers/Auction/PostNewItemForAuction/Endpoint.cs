using System;
using System.Collections.Generic;
using ExampledApi.Controllers.Auction.GetAuctionedItems;
using Microsoft.AspNetCore.Mvc;

namespace ExampledApi.Controllers.Auction.PostNewItemForAuction
{
    public class Endpoint : AuctionController
    {
        /// <summary>
        /// Register an item to be sold at the given auction.
        /// </summary>
        [HttpPost("items")]
        public ActionResult Post(Guid auctionId, Request item)
        {
            var newItemId = Guid.NewGuid().ToString();
            return new CreatedResult($"items/{newItemId}", new { Id = newItemId});
        }
    }
}