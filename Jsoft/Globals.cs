using System;
using System.Globalization;
using JetBrains.Annotations;

namespace Jsoft
{
    [PublicAPI]
    public static class Globals
    {
        public static IFormatProvider DateTimeFormat { get; } = new DateTimeFormatInfo{
            FullDateTimePattern = "yyyy-MM-ddTHH:mm:ssZ"
        };
    }
}
