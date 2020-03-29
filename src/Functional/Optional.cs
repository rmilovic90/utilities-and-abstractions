using System;

namespace UtilitiesAndAbstractions.Functional
{
    public abstract class Optional
    {
        public static Optional Of<T>(T value) =>
            value == null
                ? OfNone()
                : OfSome(value);

        public static Optional OfSome<T>(T value) => new Some<T>(value);

        public static Optional OfNone() => new None();
    }

    public sealed class Some<T> : Optional
    {
        internal Some(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            Value = value;
        }

        public T Value { get; }
    }

    public sealed class None : Optional
    {
        internal None() { }
    }
}