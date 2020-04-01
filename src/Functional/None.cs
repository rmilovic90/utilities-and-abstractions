namespace UtilitiesAndAbstractions.Functional
{
    public sealed class None<T> : Optional<T>
    {
        internal None() { }

        public override T Unwrap(T fallbackValue = default) => fallbackValue;
    }
}