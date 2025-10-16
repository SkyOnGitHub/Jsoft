using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Jsoft.EventSub.Objects.Transports.Enums;

namespace Jsoft.EventSub.Objects.Transports
{
    /// <summary>
    /// Defines the transport details that you want Twitch to use when sending you event notifications via <see cref="TransportMethod.Webhook">Webhook</see>.
    /// </summary>
    [PublicAPI]
    public sealed class WebhookTransport : Transport
    {
        /// <inheritdoc />
        protected override string _Callback {
            get => this.Callback;
            set => this.Callback = value;
        }
        
        /// <summary>
        /// Gets or sets the callback URL where the notifications are sent.
        /// </summary>
        /// <returns>The callback URL where the notifications are sent.</returns>
        /// <remarks>
        /// The URL must use the HTTPS protocol and port 443.
        /// See <see href="https://dev.twitch.tv/docs/eventsub/handling-webhook-events#processing-an-event">Processing an event</see>.<br/>
        /// Redirects are not followed.
        /// </remarks>
        [JsonIgnore]
        public string Callback { get; set; }
        
        /// <inheritdoc />
        public override TransportMethod Method => TransportMethod.Webhook;
        
        /// <inheritdoc />
        protected override string _Secret {
            get => this.Secret;
            set => this.Secret = value;
        }
        
        /// <summary>
        /// Gets or sets the secret used to verify the signature.
        /// </summary>
        /// <returns>The secret used to verify the signature.</returns>
        /// <remarks>
        /// The secret must be an ASCII string that’s a minimum of 10 characters long and a maximum of 100 characters long.
        /// For information about how the secret is used, see <see href="https://dev.twitch.tv/docs/eventsub/handling-webhook-events#verifying-the-event-message">Verifying the event message</see>.
        /// </remarks>
        [JsonIgnore]
        public string Secret { get; set; }
        
        /// <summary>
        /// Parses the supplied JSON into a new instance of <see cref="WebhookTransport"/>.
        /// </summary>
        /// <param name="json">The JSON string to parse into a new instance of <see cref="WebhookTransport"/>.</param>
        /// <returns>The new <see cref="WebhookTransport"/> instance.</returns>
        /// <exception cref="JsonException">Unable to parse <see cref="WebhookTransport"/> from JSON.</exception>
        public static WebhookTransport Parse( string json )
            => TwitchDto.Parse<WebhookTransport>(json);
    }
}
