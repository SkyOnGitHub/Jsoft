using System.Text.Json;
using System.Text.Json.Serialization;

namespace Jsoft.Tests;

internal partial class FunctionalityTests
{
    private protected class outerMock : TwitchDto
    {
        internal static outerMock Parse( string json )
            => Parse<outerMock>(json);
        
        [JsonConverter(typeof(converterMock))]
        public required baseMock Derived { get; set; }
    }
}
