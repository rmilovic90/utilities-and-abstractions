using FluentAssertions;
using Xunit;

namespace UtilitiesAndAbstractions.Functional
{
    public sealed class OptionalTests
    {
        [Fact]
        public void CanBeOfSomeValue()
        {
            var optional = Optional.OfSome("some value");

            optional.Should().BeOfType(typeof(Some<string>));
        }

        [Fact]
        public void CanBeOfNoneValue()
        {
            var optional = Optional.OfNone();

            optional.Should().BeOfType(typeof(None));
        }

        [Fact]
        public void UnwrapsUnderlyingValueWhenItIsPresent()
        {
            var optional = Optional.OfSome("some value");

            var value = optional.Unwrap("fallback value");

            value.Should().Be("some value");
        }

        [Fact]
        public void UnwrapsFallbackValueWhenUnderlyingValueIsNotPresent()
        {
            var optional = Optional.OfNone();

            var value = optional.Unwrap("fallback value");

            value.Should().Be("fallback value");
        }
    }
}