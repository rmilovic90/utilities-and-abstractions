using System;

namespace UtilitiesAndAbstractions.Functional
{
    public sealed class Some<T> : Optional<T>
    {
        internal Some(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            Value = value;
        }

        public T Value { get; }

        public override T Unwrap(T fallbackValue = default) => Value;

        public override Optional<TMapped> Map<TMapped>(Func<T, TMapped> mapper) =>
            Optional<TMapped>.OfSome(mapper(Value));

        public override TMapped Fold<TMapped>(Func<T, TMapped> mapper, TMapped fallbackValue = default) =>
            mapper(Value);
    }
}