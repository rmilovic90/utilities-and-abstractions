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
            Value = value;
        }

        public T Value { get; }
    }

    public sealed class None : Optional
    {
    }
}