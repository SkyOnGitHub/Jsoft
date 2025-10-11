using System.Text.Json;
using Jsoft.Converters;

namespace Jsoft.Tests;

internal partial class FunctionalityTests
{
    private protected class converterMock : TwitchDtoConverter<baseMock>
    {
        /// <inheritdoc />
        protected override Type DetermineTypeToConvert( Utf8JsonReader reader, Type typeToConvert )
            => typeof(derivedMock);
    }
}
