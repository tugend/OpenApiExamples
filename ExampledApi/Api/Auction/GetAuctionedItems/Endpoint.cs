using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ExampledApi.Domain.FakeAuctionItemGenerator;

namespace ExampledApi.Api.Auction.GetAuctionedItems
{
    public class Endpoint : AuctionController
    {
        /// <summary>
        /// Get all items for sale at the auction defined by <paramref name="auctionId"/>.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpGet("items")]
        public ActionResult<List<Response>> GetAuctionedItems(Guid auctionId)
        {
            var fakeRiceAuctionId = Guid.Parse("6417b261-b4d4-45bb-b141-0d0a9c1ea0f8");
            if (auctionId != fakeRiceAuctionId)
            {
                return new NotFoundObjectResult(new {Message = "Unknown auction id" });
            }
            
            return new CreatedResult($"/items/{Guid.NewGuid()}", new List<Response>
            {
                FakeAuctionedFoodStockResponse(),
                FakeAuctionedFoodStockResponse(),
                FakeAuctionedFoodStockResponse(),
                FakeAuctionedFoodStockResponse()
            });
        }
    }
}