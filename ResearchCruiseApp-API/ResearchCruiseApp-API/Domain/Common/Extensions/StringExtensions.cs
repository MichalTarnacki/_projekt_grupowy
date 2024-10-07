namespace ResearchCruiseApp_API.Domain.Common.Extensions;


public static class StringExtensions
{
    public static bool ToBool(this string value)
    {
        return string.IsNullOrEmpty(value) &&
               !value.Equals("false", StringComparison.CurrentCultureIgnoreCase);
    }

    public static T ToEnum<T>(this string value) where T : struct
    {
        if (!typeof(T).IsEnum)
            throw new ArgumentException("T must be an enum.");

        return (T)Enum.Parse(typeof(T), value);
    }
}