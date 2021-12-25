namespace ExampledApi.Api.Auction.PutBid
{
    public record Request
    {
        /// <example>750</example>
        public int AmountDkk { get; init; }
    }
}