namespace Domain.Extensions
{
    using System;

    static class DateTimeExtensions
    {
        public static DateTimeOffset ToUnixOffset(this string value) => DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(value));
    }
}
