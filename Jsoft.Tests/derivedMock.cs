namespace Jsoft.Tests;

internal partial class FunctionalityTests
{
    private protected class derivedMock : baseMock
    {
        public required object? Empty { get; init; }
        
        public required enumMock Enum { get; init; }
        
        public required DateTime Now { get; init; }
        
        public required int Value { get; init; }
    }
}
