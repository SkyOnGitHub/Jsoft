using System;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Jsoft.EventSub.Objects.Transports.Enums;

namespace Jsoft.EventSub.Objects.Transports
{
    /// <summary>
    /// Defines the transport details that you want Twitch to use when sending you event notifications.
    /// </summary>
    [PublicAPI]
    public abstract class Transport : TwitchDto
    {
        /// <summary>
        /// Gets or sets the callback URL where the notifications are sent.
        /// </summary>
        /// <returns>The callback URL where the notifications are sent.</returns>
        /// <remarks>
        /// The URL must use the HTTPS protocol and port 443.
        /// See <see href="https://dev.twitch.tv/docs/eventsub/handling-webhook-events#processing-an-event">Processing an event</see>.<br/>
        /// Specify this property only if <see cref="Method"/> is set to <see cref="TransportMethod.Webhook">Webhook</see>.<br/>
        /// Redirects are not followed.
        /// </remarks>
        [JsonInclude, JsonPropertyName("callback"), CanBeNull]
        protected virtual string _Callback {
            get => null;
            set {
                return;
            }
        }
        
        /// <summary>
        /// Gets or sets the UTC date and time that the WebSocket connection was established.
        /// </summary>
        /// <returns>The UTC date and time that the WebSocket connection was established.</returns>
        /// <remarks>
        /// This is a response-only property that <see href="https://dev.twitch.tv/docs/api/reference#create-eventsub-subscription">Create EventSub Subscription</see>
        /// and <see href="https://dev.twitch.tv/docs/api/reference#get-eventsub-subscriptions">Get EventSub Subscription</see> return
        /// if the <see cref="Method"/> property is set to <see cref="TransportMethod.Websocket">Websocket</see>.
        /// </remarks>
        [JsonInclude, JsonPropertyName("connected_at"), CanBeNull]
        protected virtual DateTime? _ConnectedAt {
            get => null;
            set {
                return;
            }
        }
        
        /// <summary>
        /// Gets or sets the UTC date and time that the WebSocket connection was lost.
        /// </summary>
        /// <returns>The UTC date and time that the WebSocket connection was lost.</returns>
        /// <remarks>
        /// This is a response-only property that <see href="https://dev.twitch.tv/docs/api/reference#get-eventsub-subscriptions">Get EventSub Subscription</see> returns
        /// if the <see cref="Method"/> property is set to <see cref="TransportMethod.Websocket">Websocket</see>.
        /// </remarks>
        [JsonInclude, JsonPropertyName("disconnected_at"), CanBeNull]
        protected virtual DateTime? _DisconnectedAt {
            get => null;
            set {
                return;
            }
        }
        
        /// <summary>
        /// Gets the transport method.
        /// </summary>
        /// <returns>The transport method.</returns>
        public abstract TransportMethod Method { get; }
        
        /// <summary>
        /// Gets or sets the secret used to verify the signature.
        /// </summary>
        /// <returns>The secret used to verify the signature.</returns>
        /// <remarks>
        /// The secret must be an ASCII string that’s a minimum of 10 characters long and a maximum of 100 characters long.
        /// For information about how the secret is used, see <see href="https://dev.twitch.tv/docs/eventsub/handling-webhook-events#verifying-the-event-message">Verifying the event message</see>.<br/>
        /// Specify this property only if <see cref="Method"/> is set to <see cref="TransportMethod.Webhook">Webhook</see>.
        /// </remarks>
        [JsonInclude, JsonPropertyName("secret"), CanBeNull]
        protected virtual string _Secret {
            get => null;
            set {
                return;
            }
        }
        
        /// <summary>
        /// Gets or sets the ID that identifies the WebSocket to send notifications to.
        /// </summary>
        /// <returns>The ID that identifies the WebSocket to send notifications to.</returns>
        /// <remarks>
        /// When you connect to EventSub using WebSockets, the server returns the ID in the <see href="https://dev.twitch.tv/docs/eventsub/handling-websocket-events#welcome-message">Welcome message</see>.<br/>
        /// Specify this property only if <see cref="Method"/> is set to <see cref="TransportMethod.Websocket">Websocket</see>.
        /// </remarks>
        [JsonInclude, JsonPropertyName("session_id"), CanBeNull]
        protected virtual string _SessionId {
            get => null;
            set {
                return;
            }
        }
    }
}
