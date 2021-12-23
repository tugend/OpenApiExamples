using System;
using Microsoft.AspNetCore.Mvc;

namespace ExampledApi.Controllers.Auction.PutBid
{
    public class Endpoint : AuctionController
    {
        /// <summary>
        /// Bid on a selected auction item.
        /// </summary>
        /// <remarks>
        /// Please note only bids equal or greater than the minimum bid for the item are accepted.
        /// </remarks>
        [HttpPut("items/{itemId:guid}")]
        public ActionResult PutBid(Guid auctionId, Guid itemId, Request request)
        {
            if (request.Amount <= 100)
            {
                return BadRequest("Bid was too low, minimum bid is 100 DKK");
            }
            
            // defaults to 200 OK even though we return Accepted!
            // TODO: how to auto generate this? 
            return Accepted($"Your bid for item {itemId} at auction {auctionId} of {request} was accepted");
        }
    }
}