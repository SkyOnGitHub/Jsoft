using System;
using System.Text.Json;
using JetBrains.Annotations;
using Jsoft.EventSub.Objects.Transports;
using Jsoft.EventSub.Objects.Transports.Enums;

namespace Jsoft.Converters
{
    /// <summary>
    /// Represents a JSON converter for the <see cref="Transport"/> data transfer object.
    /// </summary>
    [PublicAPI]
    public class TransportConverter : TwitchDtoConverter<Transport>
    {
        /// <inheritdoc />
        protected override Type DetermineTypeToConvert( Utf8JsonReader reader, Type typeToConvert )
        {
            var root = JsonDocument.ParseValue(ref reader).RootElement;
            var methodProperty = root.GetProperty("method");
            var transportMethod = methodProperty.Deserialize<TransportMethod>(TwitchDto.Options);
            switch (transportMethod) {
                case TransportMethod.Webhook:
                    return typeof(WebhookTransport);
                case TransportMethod.Websocket:
                    return typeof(WebsocketTransport);
                default:
                    throw new NotSupportedException($"Unknown transport method: {transportMethod}");
            }
        }
    }
}
