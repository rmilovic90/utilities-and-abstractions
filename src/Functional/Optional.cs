namespace UtilitiesAndAbstractions.Functional
{
    public static class Optional
    {
        public static Optional<T> OfSome<T>(T value) => new Some<T>();
    }

    public abstract class Optional<T>
    {
    }

    public sealed class Some<T> : Optional<T>
    {
    }
}