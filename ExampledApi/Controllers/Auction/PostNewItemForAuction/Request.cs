using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using ExampledApi.Controllers.Auction.Common;

namespace ExampledApi.Controllers.Auction.PostNewItemForAuction
{
    public record Request
    {
        [Required]
        public Guid SellerId { get; init; }
        // TODO: require all fields to be attribute marked, and figure out how to 
        // use both nullable and non-nullable annotations and responses,
        // use both required and optional annotations for requests
        
        [Required]
        public int MinimumBidDkk { get; init; }
        
        [Required]
        public decimal QuantityKg { get; init; }
        
        [Required]
        public RiceQuality RiceQuality { get; init; }
    }
}