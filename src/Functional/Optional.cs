namespace UtilitiesAndAbstractions.Functional
{
    public abstract class Optional<T>
    {
        public static Optional<T> Of(T value) =>
            value == null
                ? OfNone()
                : OfSome(value);

        public static Optional<T> OfSome(T value) => new Some<T>(value);

        public static Optional<T> OfNone() => new None<T>();

        public abstract T Unwrap(T fallbackValue = default);
    }
}