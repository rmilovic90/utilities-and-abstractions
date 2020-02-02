using System;
using System.Collections.Generic;

namespace UtilitiesAndAbstractions.Functional
{
    public abstract class Optional
    {
        public static Optional OfSome<T>(T value) => new Some<T>(value);

        public static Optional OfNone() => new None();
    }

    public sealed class Some<T> : Optional
    {
        public Some(T value)
        {
            if (!typeof(T).IsValueType
                && EqualityComparer<T>.Default.Equals(value, default))
            {
                throw new ArgumentNullException(nameof(value));
            }

            Value = value;
        }

        public T Value { get; }
    }

    public sealed class None : Optional
    {
    }
}