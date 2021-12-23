using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace ExampledApi.Controllers.Auction.PutBid
{
    /// <summary>
    /// WTF: https://jones.bz/c-8-0-nullable-reference-types-in-web-api-validation/
    /// </summary>
    public record Request
    {
        // TODO: for fuck sake, just ensure that all nullable values are not-required
        // and all non-nullable values are required, how fucking hard can it be!!!
        // [BindRequired]
        [Required] // requires with newtonstoft
        public int? Amount { get; init; }
        
        public string Title { get; init; }

        // https://stackoverflow.com/questions/50910093/asp-net-core-require-non-nullable-types
        // public string AnotherAmount { get; init; } = default!;
        //
        // public string? SomethingElse { get; init; } 
        
        // TODO: can we use ctor instead?
        
        /// 1. int vs int? https://stackoverflow.com/questions/50910093/asp-net-core-require-non-nullable-types
        /// int should be required, int? should be optional
        /// required should indicate key in json and not null
        /// 
        /// 2. string vs string? same, apparently behavior is NOT the same (nullable reference types)
        ///
        /// 3. how to make all values required/notnull by default unless otherwise annotated?
    }
}