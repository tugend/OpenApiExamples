using System;

namespace ExampledApi.Domain
{
    public static class FakeHelper
    {
        private static readonly Random Rnd = new();

        public static T Pick<T>(params T[] values) => values[Rnd.Next(0, values.Length)];
    }
}