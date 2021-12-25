using System.Linq;

namespace ExampledApi.Infrastructure.Utils
{
    public static class StringExtensions
    {
        public static string StripUntil(this string target, char match, int n)
        {
            var nthMatch = target
                .Select((x, i) => new { Value = x, Index = i})
                .SkipWhile(x => x.Value != match || --n > 0)
                .FirstOrDefault();
            
            if (nthMatch == null) 
                return target;
            
            var targetIndex = nthMatch
                .Index + 1;

            return target.Length <= targetIndex 
                ? target 
                : target[targetIndex..];
        }
    }
}