using System;
using FluentAssertions;
using Xunit;

namespace UtilitiesAndAbstractions.Functional
{
    public sealed class OptionalTests
    {
        [Fact]
        public void Can_be_of_some_value()
        {
            var optional = Optional.OfSome("some value");

            optional.Should().BeOfType(typeof(Some<string>));
        }

        [Fact]
        public void Accepts_default_value_of_a_value_type_as_the_underlying_value()
        {
            Action createOptional = () => Optional.OfSome(default(int));

            createOptional.Should().NotThrow();
        }

        [Fact]
        public void Rejects_null_value_of_a_reference_type_as_the_underlying_value()
        {
            Action createOptional = () => Optional.OfSome<string>(null);

            createOptional.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void Can_be_of_none_value()
        {
            var optional = Optional.OfNone();

            optional.Should().BeOfType(typeof(None));
        }

        [Fact]
        public void Unwraps_underlying_value_when_having_some_value()
        {
            var optional = Optional.OfSome("some value");

            var value = optional.Unwrap("fallback value");

            value.Should().Be("some value");
        }

        [Fact]
        public void Unwraps_fallback_value_when_having_none_value()
        {
            var optional = Optional.OfNone();

            var value = optional.Unwrap("fallback value");

            value.Should().Be("fallback value");
        }
    }
}