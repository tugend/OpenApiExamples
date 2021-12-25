using System;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;

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
        [ProducesResponseType(Status202Accepted)]
        public ActionResult PutBid(Guid auctionId, Guid itemId, Request request)
        {
            if (request.AmountDkk <= 100)
            {
                return BadRequest("Bid was too low, minimum bid is 100 DKK");
            }
            
            return Accepted($"Your bid for item {itemId} at auction {auctionId} of {request} was accepted");
        }
    }
}