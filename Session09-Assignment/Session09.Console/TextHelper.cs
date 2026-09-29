
using System.Linq;

public static class TextHelper
{
    // Normal static method.
    public static bool IsShorterThanNormal(string value, int length)
    {
        return value.Length < length;
    }

    // Extension method.
    public static bool IsShorterThan(this string value, int length)
    {
        return value.Length < length;
    }

    public static string Repeat(this string value, int times)
    {
        if (times <= 0)
        {
            return string.Empty;
        }

        return string.Concat(Enumerable.Repeat(value, times));
    }
}