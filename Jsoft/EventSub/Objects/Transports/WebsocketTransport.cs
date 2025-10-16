using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Jsoft.EventSub.Objects.Transports.Enums;

namespace Jsoft.EventSub.Objects.Transports
{
    /// <summary>
    /// Defines the transport details that you want Twitch to use when sending you event notifications via <see cref="TransportMethod.Websocket">Websocket</see>.
    /// </summary>
    [PublicAPI]
    public sealed class WebsocketTransport : Transport
    {
        /// <inheritdoc />
        protected override DateTime? _ConnectedAt {
            get => this.ConnectedAt;
            set => this.ConnectedAt = value;
        }
        
        /// <summary>
        /// Gets or sets the UTC date and time that the WebSocket connection was established.
        /// </summary>
        /// <returns>The UTC date and time that the WebSocket connection was established.</returns>
        /// <remarks>
        /// This is a response-only property that <see href="https://dev.twitch.tv/docs/api/reference#create-eventsub-subscription">Create EventSub Subscription</see>
        /// and <see href="https://dev.twitch.tv/docs/api/reference#get-eventsub-subscriptions">Get EventSub Subscription</see> return.
        /// </remarks>
        [JsonIgnore]
        public DateTime? ConnectedAt { get; set; }
        
        /// <inheritdoc />
        protected override DateTime? _DisconnectedAt {
            get => this.DisconnectedAt;
            set => this.DisconnectedAt = value;
        }
        
        /// <summary>
        /// Gets or sets the UTC date and time that the WebSocket connection was lost.
        /// </summary>
        /// <returns>The UTC date and time that the WebSocket connection was lost.</returns>
        /// <remarks>
        /// This is a response-only property that <see href="https://dev.twitch.tv/docs/api/reference#get-eventsub-subscriptions">Get EventSub Subscription</see> returns.
        /// </remarks>
        [JsonIgnore]
        public DateTime? DisconnectedAt { get; set; }
        
        /// <inheritdoc />
        public override TransportMethod Method => TransportMethod.Websocket;
        
        /// <inheritdoc />
        protected override string _SessionId {
            get => this.SessionId;
            set => this.SessionId = value;
        }
        
        /// <summary>
        /// Gets or sets the ID that identifies the WebSocket to send notifications to.
        /// </summary>
        /// <returns>The ID that identifies the WebSocket to send notifications to.</returns>
        /// <remarks>
        /// When you connect to EventSub using WebSockets, the server returns the ID in the <see href="https://dev.twitch.tv/docs/eventsub/handling-websocket-events#welcome-message">Welcome message</see>.
        /// </remarks>
        [JsonIgnore]
        public string SessionId { get; set; }
        
        /// <summary>
        /// Parses the supplied JSON into a new instance of <see cref="WebsocketTransport"/>.
        /// </summary>
        /// <param name="json">The JSON string to parse into a new instance of <see cref="WebsocketTransport"/>.</param>
        /// <returns>The new <see cref="WebsocketTransport"/> instance.</returns>
        /// <exception cref="JsonException">Unable to parse <see cref="WebsocketTransport"/> from JSON.</exception>
        public static WebsocketTransport Parse( string json )
            => TwitchDto.Parse<WebsocketTransport>(json);
    }
}
