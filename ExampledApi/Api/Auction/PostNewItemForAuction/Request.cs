using System.ComponentModel.DataAnnotations;
using ExampledApi.Api.Auction.Common;
using JetBrains.Annotations;

namespace ExampledApi.Api.Auction.PostNewItemForAuction
{
    [PublicAPI]
    public record Request
    {
        /// <example>606</example>
        [RegularExpression(".{3}.*", ErrorMessage = "Seller id must be at least three characters.")]
        public string SellerId { get; init; } = null!;

        /// <example>250</example>
        public int? MinimumBidDkk { get; init; }
        
        /// <example>5</example>
        [Required]
        public decimal QuantityKg { get; init; }
        
        /// <example>Gold</example>
        public RiceQuality RiceQuality { get; init; }
        
        /// <example>Johnson Groceries VA</example>
        public string? SellerName { get; init; }
    }
}