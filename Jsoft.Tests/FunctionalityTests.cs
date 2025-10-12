using System.Text;

namespace Jsoft.Tests;

internal partial class FunctionalityTests : TestsBase
{
    private const enumMock ENUM  = enumMock.Two;
    private const string   NAME  = "AnswerToEverything";
    private const int      VALUE = 42;
    
    private static readonly DateTime now = DateTime.UtcNow;
    
    private static readonly string json = new StringBuilder()
                                          .Append('{')
                                          .Append("\"derived\":")
                                          .Append('{')
                                          .Append("\"empty\":null,")
                                          .Append($"\"enum\":\"{ENUM.ToString().ToLower()}\",")
                                          .Append($"\"now\":\"{now.ToString(Globals.DateTimeFormat)}\",")
                                          .Append($"\"value\":\"{VALUE}\",")
                                          .Append($"\"name\":\"{NAME}\"")
                                          .Append('}')
                                          .Append('}')
                                          .ToString();
    
    private static readonly outerMock value = new(){
        Derived = new derivedMock{
            Name  = NAME,
            Empty = null,
            Enum  = ENUM,
            Now   = now,
            Value = VALUE
        }
    };
    
    [Test]
    public void ParseTest()
        => assertDeserializable(value, json);
    
    [Test]
    public void PrintTest()
        => assertSerializable(value, json);
}
