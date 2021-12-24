using JetBrains.Annotations;

namespace ExampledApi.Controllers.Auction.PutBid
{
    [PublicAPI]
    public record Request
    {
        /// <example>750</example>
        public int AmountDkk { get; init; }
    }
}