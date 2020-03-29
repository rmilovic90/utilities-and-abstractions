namespace UtilitiesAndAbstractions.Functional
{
    public static class OptionalExtensions
    {
        public static T Unwrap<T>(this Optional optional, T fallbackValue = default) =>
            optional is Some<T> some
                ? some.Value
                : fallbackValue;
    }
}