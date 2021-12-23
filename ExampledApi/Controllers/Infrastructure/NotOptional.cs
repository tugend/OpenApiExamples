using System.ComponentModel.DataAnnotations;

namespace ExampledApi.Controllers.Infrastructure
{
    public class NotOptionalAttribute : RequiredAttribute
    {
        public NotOptionalAttribute()
        {
            // AllowEmptyStrings = false;
        }
    }
}