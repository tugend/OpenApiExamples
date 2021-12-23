using System;

namespace ExampledApi.Controllers.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class OptionalAttribute : Attribute
    {
     
    }
}