namespace UtilitiesAndAbstractions.Functional
{
    public static class OptionalExtensions
    {
        public static T Unwrap<T>(this Optional optional, T fallbackValue) =>
            optional is Some<T> some
                ? some.Value
                : fallbackValue;
    }
}