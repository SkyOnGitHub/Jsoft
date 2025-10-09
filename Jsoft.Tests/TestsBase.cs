using JetBrains.Annotations;

namespace Jsoft.Tests;

internal abstract class TestsBase
{
    [AssertionMethod]
    private protected void deserializationTest< TValue >( TValue value, string json )
    where TValue : TwitchDto
    {
        // Act
        var actual = TwitchDto.Parse<TValue>(json);
        
        // Assert
        Assert.That(actual, Is.EqualTo(value));
    }
    
    [AssertionMethod]
    private protected void serializationTest< TValue >( TValue value, string json )
    where TValue : TwitchDto
    {
        // Act
        var actual = value.ToJson();
        
        // Assert
        Assert.That(actual, Is.EqualTo(json));
    }
}
