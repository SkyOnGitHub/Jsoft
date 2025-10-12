namespace Jsoft.Tests;

internal partial class FunctionalityTests : TestsBase
{
    private const string JSON = "{\"Derived\":{\"Value\":\"42\",\"Name\":\"AnswerToEverything\"}}";
    
    private static readonly outerMock value = new(){ Derived = new derivedMock{ Name = "AnswerToEverything", Value = 42 } };
    
    [Test]
    public void ParseTest()
        => assertDeserializable(value, JSON);
    
    [Test]
    public void PrintTest()
        => assertSerializable(value, JSON);
}
