using System;
using JetBrains.Annotations;

namespace ExampledApi.Api.Auction.PostNewItemForAuction
{
    [PublicAPI]
    public record Response
    {
        public string SellerId { get; }
        public string? SellerName { get; }
        public string ItemId { get; }
        public DateTimeOffset RegistrationTime { get; }

        public Response(string id, DateTimeOffset registrationTime, string sellerId, string? sellerName)
        {
            ItemId = id;
            RegistrationTime = registrationTime;
            SellerId = sellerId;
            SellerName = sellerName;
        }
    }
}