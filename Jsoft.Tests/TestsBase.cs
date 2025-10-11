using JetBrains.Annotations;

namespace Jsoft.Tests;

internal abstract class TestsBase
{
    [AssertionMethod]
    private protected static void assertDeserializable< TValue >( TValue value, string json )
    where TValue : TwitchDto
    {
        // Act
        var actual = TwitchDto.Parse<TValue>(json);
        
        // Assert
        Assert.That(actual, Is.EqualTo(value));
    }
    
    [AssertionMethod]
    private protected static void assertSerializable< TValue >( TValue value, string json )
    where TValue : TwitchDto
    {
        // Act
        var actual = value.ToString();
        
        // Assert
        Assert.That(actual, Is.EqualTo(json));
    }
}
