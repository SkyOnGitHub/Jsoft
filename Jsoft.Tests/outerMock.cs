using System.Text.Json;
using System.Text.Json.Serialization;

namespace Jsoft.Tests;

internal partial class FunctionalityTests
{
    private protected class outerMock : TwitchDto
    {
        [JsonConverter(typeof(converterMock))]
        public required baseMock Derived { get; set; }
    }
}
