using System.Text;
using Jsoft.EventSub.Objects.Transports;
using Jsoft.EventSub.Objects.Transports.Enums;

namespace Jsoft.Tests.DataTransferObjectTests.Objects.Transports;

internal class TransportTests : TestsBase
{
    private const string          CALLBACK = "test.url";
    private const TransportMethod METHOD   = TransportMethod.Webhook;
    private const string          SECRET   = "example123";
    
    private static readonly string json = new StringBuilder()
                                          .Append('{')
                                          .Append($"\"callback\":\"{CALLBACK}\",")
                                          .Append($"\"method\":\"{METHOD.ToString().ToLower()}\",")
                                          .Append($"\"secret\":\"{SECRET}\",")
                                          .Append("\"connected_at\":null,")
                                          .Append("\"disconnected_at\":null,")
                                          .Append("\"session_id\":null")
                                          .Append('}')
                                          .ToString();
    
    private static readonly Transport value = new WebhookTransport{
        Callback = CALLBACK,
        Secret   = SECRET,
    };
    
    [Test]
    public void ParseTest()
        => assertDeserializable(value, json);
    
    [Test]
    public void PrintTest()
        => assertSerializable(value, json);
}
