namespace Jsoft.Tests;

internal partial class FunctionalityTests
{
    private protected abstract class baseMock : TwitchDto
    {
        public required string Name { get; init; }
    }
}
