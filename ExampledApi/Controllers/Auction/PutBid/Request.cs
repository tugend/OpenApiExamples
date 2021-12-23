using System.ComponentModel.DataAnnotations;
using ExampledApi.Controllers.Infrastructure;

namespace ExampledApi.Controllers.Auction.PutBid
{
    /// <summary>
    /// WTF: https://jones.bz/c-8-0-nullable-reference-types-in-web-api-validation/
    /// </summary>
    public record Request
    {
        // TODO: for fuck sake, just ensure that all nullable values are not-required
        // and all non-nullable values are required, how fucking hard can it be!!!
        [Required]
        public int Amount { get; init; } = default!;

        public string AnotherAmount { get; init; } = default!;
        
        public string? SomethingElse { get; init; } 
        
        // TODO: can we use ctor instead?
    }
}