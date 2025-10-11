namespace Jsoft.Tests;

internal partial class FunctionalityTests
{
    private protected class derivedMock : baseMock
    {
        public required int Value { get; init; }
    }
}
