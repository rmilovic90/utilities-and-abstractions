using FluentAssertions;
using Xunit;

namespace UtilitiesAndAbstractions.Functional
{
    public sealed class OptionalTests
    {
        [Fact]
        public void CanBeOfSomeValue()
        {
            var optional = Optional.OfSome("Some value");

            optional.Should().BeOfType(typeof(Some<string>));
        }

        [Fact]
        public void CanBeOfNoneValue()
        {
            var optional = Optional.OfNone();

            optional.Should().BeOfType(typeof(None));
        }
    }
}