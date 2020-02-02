namespace UtilitiesAndAbstractions.Functional
{
    public abstract class Optional
    {
        public static Optional OfSome<T>(T value) => new Some<T>();

        public static Optional OfNone() => new None();
    }

    public sealed class Some<T> : Optional
    {
    }

    public sealed class None : Optional
    {
    }
}