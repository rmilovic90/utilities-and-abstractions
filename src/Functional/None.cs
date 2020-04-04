using System;

namespace UtilitiesAndAbstractions.Functional
{
    public sealed class None<T> : Optional<T>
    {
        internal None() { }

        public override T Unwrap(T fallbackValue = default) => fallbackValue;

        public override Optional<TMapped> Map<TMapped>(Func<T, TMapped> mapper) =>
            Optional<TMapped>.OfNone();

        public override TMapped Fold<TMapped>(Func<T, TMapped> mapper, TMapped fallbackValue = default) =>
            fallbackValue;
    }
}