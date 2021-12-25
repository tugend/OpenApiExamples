using System;
using Microsoft.AspNetCore.Mvc;

namespace ExampledApi.Api.Auction.PostNewItemForAuction
{
    public class Endpoint : AuctionController
    {
        /// <summary>
        /// Register an item to be sold at the given auction.
        /// </summary>
        [HttpPost("items")]
        public ActionResult<Response> PostItemForAuction(Guid auctionId, Request item)
        {
            var newItemId = Guid.NewGuid().ToString();
            return new Response(newItemId, DateTimeOffset.Now, item.SellerId, item.SellerName);
        }
    }
}