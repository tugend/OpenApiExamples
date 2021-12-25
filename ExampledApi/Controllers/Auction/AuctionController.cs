using Microsoft.AspNetCore.Mvc;

namespace ExampledApi.Controllers.Auction
{
    /// <summary>
    /// Public API for sellers and buyers.
    /// </summary>
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/v1/food-stock/auctions/{auctionId:guid}")]  
    public class AuctionController : ControllerBase
    {
        
    }
}