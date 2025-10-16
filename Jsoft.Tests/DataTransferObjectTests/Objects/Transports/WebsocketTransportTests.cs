using System.Text;
using Jsoft.EventSub.Objects.Transports;
using Jsoft.EventSub.Objects.Transports.Enums;

namespace Jsoft.Tests.DataTransferObjectTests.Objects.Transports;

internal class WebsocketTransportTests : TestsBase
{
    private const TransportMethod METHOD     = TransportMethod.Websocket;
    private const string          SESSION_ID = "Super Awesome Session ID";
    
    private static readonly DateTime connectedAt    = DateTime.UtcNow;
    private static readonly DateTime disconnectedAt = DateTime.UtcNow;
    
    private static readonly string json = new StringBuilder()
                                          .Append('{')
                                          .Append($"\"connected_at\":\"{connectedAt.ToString(Globals.DateTimeFormat)}\",")
                                          .Append($"\"disconnected_at\":\"{disconnectedAt.ToString(Globals.DateTimeFormat)}\",")
                                          .Append($"\"method\":\"{METHOD.ToString().ToLower()}\",")
                                          .Append($"\"session_id\":\"{SESSION_ID}\",")
                                          .Append($"\"callback\":null,")
                                          .Append($"\"secret\":null")
                                          .Append('}')
                                          .ToString();
    
    private static readonly WebsocketTransport value = new WebsocketTransport{
        ConnectedAt    = connectedAt,
        DisconnectedAt = disconnectedAt,
        SessionId      = SESSION_ID
    };
    
    [Test]
    public void ParseTest()
        => assertDeserializable(value, json);
    
    [Test]
    public void PrintTest()
        => assertSerializable(value, json);
}
