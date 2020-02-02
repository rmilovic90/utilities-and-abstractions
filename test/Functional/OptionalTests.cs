using FluentAssertions;
using Xunit;

namespace UtilitiesAndAbstractions.Functional
{
    public sealed class OptionalTests
    {
        [Fact]
        public void AcceptsSomeValue()
        {
            var optional = Optional.OfSome("Some value");

            optional.Should().BeOfType(typeof(Some<string>));
        }
    }
}