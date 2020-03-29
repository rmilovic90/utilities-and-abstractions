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

            optional.Should().BeOfType<Some<string>>();
            optional.As<Some<string>>().Value.Should().Be("some value");
        }

        [Fact]
        public void Accepts_default_value_of_a_value_type_as_the_underlying_value()
        {
            Action createOptional = () => Optional.OfSome(default(int));

            createOptional.Should().NotThrow();
        }

        [Fact]
        public void Rejects_null_value_of_a_nullable_value_type_as_the_underlying_value()
        {
            Action createOptional = () => Optional.OfSome<int?>(null);

            createOptional.Should().ThrowExactly<ArgumentNullException>();
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

            optional.Should().BeOfType<None>();
        }

        [Fact]
        public void Unwraps_underlying_value_when_having_some_value()
        {
            var optional = Optional.OfSome("some value");

            var value = optional.Unwrap("fallback value");

            value.Should().Be("some value");
        }

        [Fact]
        public void Unwraps_provided_fallback_value_when_having_none_value()
        {
            var optional = Optional.OfNone();

            var value = optional.Unwrap("fallback value");

            value.Should().Be("fallback value");
        }

        [Fact]
        public void Unwraps_default_value_for_a_value_type_when_having_none_value_and_not_providing_fallback_value()
        {
            var optional = Optional.OfNone();

            var value = optional.Unwrap<int>();

            value.Should().Be(default);
        }

        [Fact]
        public void Unwraps_null_value_for_a_nullable_value_type_when_having_none_value_and_not_providing_fallback_value()
        {
            var optional = Optional.OfNone();

            var value = optional.Unwrap<int?>();

            value.Should().BeNull();
        }

        [Fact]
        public void Unwraps_null_value_for_a_reference_type_when_having_none_value_and_not_providing_fallback_value()
        {
            var optional = Optional.OfNone();

            var value = optional.Unwrap<string>();

            value.Should().BeNull();
        }

        [Fact]
        public void Has_none_value_when_created_from_null_value_of_a_nullable_value_type()
        {
            var optional = Optional.Of<int?>(null);

            optional.Should().BeOfType<None>();
        }

        [Fact]
        public void Has_none_value_when_created_from_null_value_of_a_reference_type()
        {
            var optional = Optional.Of<string>(null);

            optional.Should().BeOfType<None>();
        }

        [Fact]
        public void Has_some_value_when_created_from_a_value_type()
        {
            var optional = Optional.Of(1);

            optional.Should().BeOfType<Some<int>>();
            optional.As<Some<int>>().Value.Should().Be(1);
        }

        [Fact]
        public void Has_some_value_when_created_from_non_null_value_of_a_nullable_value_type()
        {
            var optional = Optional.Of<int?>(1);

            optional.Should().BeOfType<Some<int?>>();
            optional.As<Some<int?>>().Value.Should().Be(1);
        }

        [Fact]
        public void Has_some_value_when_created_from_non_null_value_of_a_reference_type()
        {
            var optional = Optional.Of("some value");

            optional.Should().BeOfType<Some<string>>();
            optional.As<Some<string>>().Value.Should().Be("some value");
        }
    }
}